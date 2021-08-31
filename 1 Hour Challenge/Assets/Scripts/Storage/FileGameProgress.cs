using HourChallenge.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace HourChallenge.Storage
{
    public class FileGameProgress : MonoBehaviour, IGameProgress
    {
        string _path;

        void Awake() => _path = $"{Application.persistentDataPath}/game-progress.data";

        public IList<Challenge> GetChallenges()
        {
            if (!File.Exists(_path))
            {
                Save(new List<Challenge>());
                return new List<Challenge>();
            }

            var file = File.Open(_path, FileMode.Open);

            try
            {
                return new BinaryFormatter().Deserialize(file) as List<Challenge>;
            }
            catch
            {
                return new List<Challenge>();
            }
            finally
            {
                file.Close();
            }
        }

        public Challenge GetChallenge(int challenge) => GetChallenges().SingleOrDefault(d => d.ChallengeNumber == challenge);

        public void AddChallenge(Challenge challenge)
        {
            var docs = GetChallenges() ?? new List<Challenge>();
            docs.Add(challenge);
            Save(docs);
        }

        public void UpdateChallenge(Challenge challenge)
        {
            DeleteChallenge(challenge.ChallengeNumber);
            AddChallenge(challenge);
        }

        public void DeleteChallenge(int challenge)
        {
            var docs = GetChallenges();
            docs.Remove(docs.Single(d => d.ChallengeNumber == challenge));
            Save(docs);
        }

        public void ClearGameProgress()
        {
            if (File.Exists(_path)) { File.Delete(_path); }
        }

        void Save(IEnumerable<Challenge> challenges)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(_path);
            bf.Serialize(file, challenges);
            file.Close();
        }
    }
}
