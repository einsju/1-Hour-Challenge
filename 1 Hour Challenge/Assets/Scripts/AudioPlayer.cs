using HourChallenge.Managers;
using UnityEngine;

namespace HourChallenge
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] AudioClip audioClip;

        protected void PlaySound() => EventManager.OnPlaySound(audioClip);
    }
}
