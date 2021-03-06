using HourChallenge.Handlers;
using HourChallenge.Storage;
using UnityEngine;

namespace HourChallenge.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        AudioSource _audioSource;
        bool _hasAudio;
        //bool _hasMusic;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _hasAudio = Preferences.HasAudio;
        }

        void OnEnable()
        {
            AudioEventHandler.PlaySound += PlaySound;
            AudioEventHandler.SoundOptionChanged += SoundOptionChanged;
        }

        void OnDisable()
        {
            AudioEventHandler.PlaySound -= PlaySound;
            AudioEventHandler.SoundOptionChanged -= SoundOptionChanged;
        }

        void PlaySound(AudioClip soundClip)
        {
            if (!_hasAudio) return;
            _audioSource.PlayOneShot(soundClip);
        }

        void SoundOptionChanged(bool value) => _hasAudio = value;
    }
}
