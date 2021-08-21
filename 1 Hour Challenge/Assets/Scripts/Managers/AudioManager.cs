using UnityEngine;

namespace HourChallenge.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        AudioSource _audioSource;

        void Awake() => _audioSource = GetComponent<AudioSource>();
            
        void OnEnable() => EnableEvents();
        void OnDisable() => DisableEvents();

        void EnableEvents()
        {
            EventManager.PlaySoundEventHandler += PlaySound;
        }

        void DisableEvents()
        {
            EventManager.PlaySoundEventHandler -= PlaySound;
        }

        void PlaySound(AudioClip soundClip) => _audioSource.PlayOneShot(soundClip);
    }
}
