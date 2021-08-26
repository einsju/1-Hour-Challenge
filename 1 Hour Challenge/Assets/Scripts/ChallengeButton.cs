using HourChallenge.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HourChallenge
{
    [ExecuteAlways]
    public class ChallengeButton : MonoBehaviour
    {
        [SerializeField] GameObject locked;
        [SerializeField] TMP_Text buttonText;
        [SerializeField] GameObject video;
        [SerializeField] Color activationColor;

        public int ChallengeNumber => _challengeNumber;

        Button _button;
        int _challengeNumber;

        bool TextIsNumber => int.TryParse(gameObject.name, out _);
        string ButtonText => TextIsNumber ? gameObject.name : "";
        bool ChallengeIsLocked => _challengeNumber > 1;

        void Awake() => InitializeButton();

        void InitializeButton()
        {
            _button = GetComponent<Button>();
            _challengeNumber = int.Parse(ButtonText);
            locked.SetActive(ChallengeIsLocked);
            video.SetActive(ChallengeIsLocked);
            buttonText.text = ButtonText;
        }

        void OnEnable() => _button.onClick.AddListener(ChallengeAccepted);
        void OnDisable() => _button.onClick.RemoveListener(ChallengeAccepted);

        void ChallengeAccepted() => ChallengeEventHandler.OnChallengeAccepted(_challengeNumber);

        public void Activate()
        {
            var shadow = GetComponent<Shadow>();
            shadow.effectColor = activationColor;
        }
    }
}
