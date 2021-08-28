using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HourChallenge.Storage
{
    public class GameProgressService : MonoBehaviour
    {
        public static int GetTotalScore() => GameProgress.Get().Sum(gp => gp.Score);

        public static IEnumerable<Challenge> GetAllChallenges() => GameProgress.Get().OrderBy(gp => gp.ChallengeNumber);

        public static void AddOrUpdateChallenge(int challengeNumber, bool completed = true, int score = 0, int rating = 3)
        {
            var challenge = GameProgress.Get(challengeNumber);
            if (challenge != null) { UpdateChallenge(challenge, completed, score, rating); return; };
            AddChallenge(challengeNumber, completed, score, rating);
        }

        static void AddChallenge(int challengeNumber, bool completed, int score, int rating) =>
            GameProgress.Add(new Challenge { ChallengeNumber = challengeNumber, Completed = completed, Score = score, Rating = rating });

        static void UpdateChallenge(Challenge challenge, bool completed, int score, int rating)
        {
            challenge.Completed = completed;
            challenge.Rating = rating;
            challenge.Score = score;
            GameProgress.Update(challenge);
        }
    }
}
