using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HourChallenge.Storage
{
    public class GameProgressService : MonoBehaviour
    {
        public static int GetTotalScore() => GameProgress.Get().Sum(gp => gp.Score);

        public static Challenge GetChallenge(int challengeNumber) => GameProgress.Get(challengeNumber);

        public static IEnumerable<Challenge> GetAllChallenges() => GameProgress.Get().OrderBy(gp => gp.ChallengeNumber);

        public static void AddOrUpdateChallenge(int challengeNumber, bool completed = true, int score = 0, int rating = 1)
        {
            var challenge = GameProgress.Get(challengeNumber);
            if (challenge != null) { UpdateChallenge(challenge, completed, score); return; };
            AddChallenge(challengeNumber, completed, score);
        }

        static void AddChallenge(int challengeNumber, bool completed, int score) =>
            GameProgress.Add(new Challenge { ChallengeNumber = challengeNumber, Completed = completed, Score = score });

        static void UpdateChallenge(Challenge challenge, bool completed, int score)
        {
            challenge.Completed = completed;
            challenge.Score = score;
            GameProgress.Update(challenge);
        }
    }
}
