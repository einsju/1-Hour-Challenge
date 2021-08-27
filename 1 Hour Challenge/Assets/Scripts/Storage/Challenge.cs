using System;

namespace HourChallenge.Storage
{
    [Serializable]
    public class Challenge
    {
        public int ChallengeNumber { get; set; }
        public bool Completed { get; set; }
        public int Score { get; set; }
        public int Rating { get; set; }
    }
}
