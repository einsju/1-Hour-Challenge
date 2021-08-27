using System;

namespace HourChallenge.Handlers
{
    public abstract class ScoreEventHandler
    {
        public static event Action<int> HighscoreLoaded;

        public static void OnHighscoreLoaded(int score) => HighscoreLoaded?.Invoke(score);
    }
}
