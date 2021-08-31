using HourChallenge.Abstractions;
using System.Linq;
using UnityEngine;

namespace HourChallenge.Storage
{
    public class GameProgressService : MonoBehaviour
    {
        static IGameProgress _gameProgress = FindObjectsOfType<MonoBehaviour>().OfType<IGameProgress>().Single();

        public static int GetTotalScore() => _gameProgress.GetChallenges().Sum(gp => gp.Score);

        public static Challenge GetChallenge(int challengeNumber) => _gameProgress.GetChallenge(challengeNumber);

        public static void AddChallenge(int challengeNumber) => _gameProgress.AddChallenge(new Challenge { ChallengeNumber = challengeNumber });

        public static void UpdateChallenge(int challengeNumber, int score)
        {
            if (score == 0) return;
            var challenge = GetChallenge(challengeNumber);
            if (challenge is null || score <= challenge.Score) return;
            challenge.Score = score;
            _gameProgress.UpdateChallenge(challenge);
        }

        public static void CompleteChallenge(int challengeNumber, int score)
        {
            var challenge = GetChallenge(challengeNumber);
            if (challenge is null) return;
            if (score > challenge.Score) challenge.Score = score;
            challenge.Completed = true;
            _gameProgress.UpdateChallenge(challenge);
        }

        public static void RestartGame() => _gameProgress.ClearGameProgress();
    }
}
