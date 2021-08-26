using System;

namespace HourChallenge.Handlers
{
    public abstract class ChallengeEventHandler
    {
        public static event Action<int> ChallengeLoaded;
        public static event Action<int> ChallengeAccepted;

        public static void OnChallengeLoaded(int challenge) => ChallengeLoaded?.Invoke(challenge);
        public static void OnChallengeAccepted(int challenge) => ChallengeAccepted?.Invoke(challenge);
    }
}
