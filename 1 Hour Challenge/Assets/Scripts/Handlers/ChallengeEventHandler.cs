using System;

namespace HourChallenge.Handlers
{
    public abstract class ChallengeEventHandler
    {
        public static event Action<int> ChallengeLoaded;
        public static event Action<int> ChallengeAccepted;
        public static event Action<int> NextChallengeAccepted;

        public static void OnChallengeLoaded(int challenge) => ChallengeLoaded?.Invoke(challenge);
        public static void OnChallengeAccepted(int challenge) => ChallengeAccepted?.Invoke(challenge);
        public static void OnNextChallengeAccepted(int currentChallenge) => NextChallengeAccepted?.Invoke(currentChallenge);
    }
}
