using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace HourChallenge.Storage
{
    public abstract class GameProgress
    {
        static readonly string path = $"{Application.persistentDataPath}/game-progress.data";

        public static IList<Challenge> Get()
        {
            if (!File.Exists(path))
            {
                Save(new List<Challenge>());
                return new List<Challenge>();
            }

            var file = File.Open(path, FileMode.Open);

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

        public static Challenge Get(int challenge) => Get().SingleOrDefault(d => d.ChallengeNumber == challenge);

        public static void Add(Challenge challenge)
        {
            var docs = Get() ?? new List<Challenge>();
            docs.Add(challenge);
            Save(docs);
        }

        public static void Update(Challenge challenge)
        {
            Delete(challenge.ChallengeNumber);
            Add(challenge);
        }

        public static void Delete(int challenge)
        {
            var docs = Get();
            docs.Remove(docs.Single(d => d.ChallengeNumber == challenge));
            Save(docs);
        }

        public static void RemoveFile()
        {
            if (File.Exists(path)) { File.Delete(path); }
        }

        static void Save(IEnumerable<Challenge> challenges)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(path);
            bf.Serialize(file, challenges);
            file.Close();
        }
    }
}
