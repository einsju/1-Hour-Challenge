using HourChallenge.Handlers;
using HourChallenge.Storage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HourChallenge
{
    [ExecuteAlways]
    public class ChallengeButton : MonoBehaviour
    {
        [SerializeField] TMP_Text buttonText;
        [SerializeField] TMP_Text scoreText;
        [SerializeField] GameObject locked;        
        [SerializeField] GameObject video;
        [SerializeField] Color activationColor;

        Button _button;
        Challenge _challenge;
        int _challengeNumber;

        bool TextIsNumber => int.TryParse(gameObject.name, out _);
        string ButtonText => TextIsNumber ? gameObject.name : "";
        bool IsCurrent => _challengeNumber == Preferences.CurrentChallenge;
        bool HasPlayedOrIsPlaying => IsCurrent || _challenge != null;
        Color NotActiveColor => new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, 0.025f);

        void Awake()
        {
            _challengeNumber = int.Parse(ButtonText);
            _challenge = GameProgressService.GetChallenge(_challengeNumber);
            _button = GetComponent<Button>();
            Initialize();
        }

        void Initialize()
        {
            locked.SetActive(!HasPlayedOrIsPlaying);
            video.SetActive(!HasPlayedOrIsPlaying);
            scoreText.gameObject.SetActive(HasPlayedOrIsPlaying);
            scoreText.text = $"{_challenge?.Score}";
            buttonText.text = ButtonText;

            if (IsCurrent) Highlight();
            if (!HasPlayedOrIsPlaying) buttonText.color = NotActiveColor;
        }

        public void Highlight()
        {
            var shadow = GetComponent<Shadow>();
            shadow.effectColor = activationColor;
        }

        void OnEnable() => _button.onClick.AddListener(AcceptChallenge);
        void OnDisable() => _button.onClick.RemoveListener(AcceptChallenge);

        void AcceptChallenge() => ChallengeEventHandler.OnChallengeAccepted(_challengeNumber);        
    }
}
