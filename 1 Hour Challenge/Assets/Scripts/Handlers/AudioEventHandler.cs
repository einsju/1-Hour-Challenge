using System;
using UnityEngine;

namespace HourChallenge.Handlers
{
    public abstract class AudioEventHandler
    {
        public static event Action<AudioClip> PlaySound;

        public static void OnPlaySound(AudioClip clip) => PlaySound?.Invoke(clip);
    }
}
