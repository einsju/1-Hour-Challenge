using System;
using UnityEngine;

namespace HourChallenge.Managers
{
    public abstract class EventManager : MonoBehaviour
    {
        public static event Action<int> ChallengeAcceptedEventHandler;
        public static event Action<AudioClip> PlaySoundEventHandler;

        public static void OnChallengeAccepted(int challenge) => ChallengeAcceptedEventHandler?.Invoke(challenge);
        public static void OnPlaySound(AudioClip clip) => PlaySoundEventHandler?.Invoke(clip);
    }
}
