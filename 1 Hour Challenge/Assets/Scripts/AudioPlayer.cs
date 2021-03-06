using HourChallenge.Handlers;
using UnityEngine;

namespace HourChallenge
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] AudioClip audioClip;

        protected void PlaySound() => AudioEventHandler.OnPlaySound(audioClip);
    }
}
