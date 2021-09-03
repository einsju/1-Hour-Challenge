using HourChallenge.Handlers;
using HourChallenge.Storage;
using UnityEngine;
using UnityEngine.UI;

namespace HourChallenge
{
    public class Options : MonoBehaviour
    {
        [SerializeField] Image soundIcon;
        [SerializeField] Sprite soundOn;
        [SerializeField] Sprite soundOff;
        [SerializeField] Image musicIcon;
        [SerializeField] Sprite musicOn;
        [SerializeField] Sprite musicOff;
        [SerializeField] Color switchedOn;
        [SerializeField] Color switchedOff;

        bool _hasAudio;
        bool _hasMusic;

        void Awake()
        {
            _hasAudio = Preferences.HasAudio;
            _hasMusic = Preferences.HasMusic;

            SetAudioButtonIcon();
            SetMusicButtonIcon();
        }

        public void OnToggleSounds()
        {
            _hasAudio = !_hasAudio;
            Preferences.SetAudio(_hasAudio);
            SetAudioButtonIcon();
            AudioEventHandler.OnSoundOptionChanged(_hasAudio);
        }

        public void OnToggleMusic()
        {
            _hasMusic = !_hasMusic;
            Preferences.SetMusic(_hasMusic);
            SetMusicButtonIcon();
            AudioEventHandler.OnMusicOptionChanged(_hasMusic);
        }

        void SetAudioButtonIcon()
        {
            soundIcon.sprite = _hasAudio ? soundOn : soundOff;
            soundIcon.color = _hasAudio ? switchedOn : switchedOff;
        }

        void SetMusicButtonIcon()
        {
            musicIcon.sprite = _hasMusic ? musicOn : musicOff;
            musicIcon.color = _hasMusic ? switchedOn : switchedOff;
        }

        public void OnRate() => Application.OpenURL("market://details?id=com.einarsen.hourchallenge");

        public void OnPrivacy() => Application.OpenURL("https://sjureinarsen.wixsite.com/hourchallenge/privacypolicy");

        public void OnRestart()
        {
            GameProgressService.RestartGame();
            ChallengeEventHandler.OnChallengeAccepted(1);
        }

        public void OnQuit() => Application.Quit();
    }
}
