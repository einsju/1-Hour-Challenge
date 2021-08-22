using UnityEngine;
using TMPro;
using UnityEngine.UI;
using HourChallenge.Managers;

namespace HourChallenge
{
    [ExecuteAlways]
    public class ChallengeButton : MonoBehaviour
    {
        [SerializeField] GameObject locked;
        [SerializeField] TMP_Text buttonText;
        [SerializeField] GameObject video;

        Button _button;
        int _challengeNumber;

        bool TextIsNumber => int.TryParse(gameObject.name, out _);
        string ButtonText => TextIsNumber ? gameObject.name : "";
        bool ChallengeIsLocked => _challengeNumber > 1;

        void Awake() => _button = GetComponent<Button>();
        void Start() => InitializeButton();

        void InitializeButton()
        {
            _challengeNumber = int.Parse(ButtonText);
            locked.SetActive(ChallengeIsLocked);
            video.SetActive(ChallengeIsLocked);
            buttonText.text = ButtonText;
        }

        void OnEnable() => _button.onClick.AddListener(ChallengeAccepted);
        void OnDisable() => _button.onClick.RemoveListener(ChallengeAccepted);

        void ChallengeAccepted() => EventManager.OnChallengeAccepted(_challengeNumber);
    }
}
