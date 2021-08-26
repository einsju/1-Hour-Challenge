using System;

namespace HourChallenge.Handlers
{
    public abstract class ScoreEventHandler
    {
        public static event Action<int> ScoreLoaded;

        public static void OnScoreLoaded(int score) => ScoreLoaded?.Invoke(score);
    }
}
