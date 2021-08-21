using UnityEngine;
using TMPro;
using UnityEngine.UI;
using HourChallenge.Managers;

namespace HourChallenge
{
    [ExecuteAlways]
    public class ChallengeButton : MonoBehaviour
    {
        [SerializeField] TMP_Text buttonText;

        Button _button;

        bool TextIsNumber => int.TryParse(gameObject.name, out _);

        void Awake() => _button = GetComponent<Button>();
        void Start() => SetChallengeText();

        void SetChallengeText()
        {
            if (!TextIsNumber) return;
            buttonText.text = gameObject.name;
        }

        void OnEnable() => _button.onClick.AddListener(ChallengeAccepted);
        void OnDisable() => _button.onClick.RemoveListener(ChallengeAccepted);

        void ChallengeAccepted() => EventManager.OnChallengeAccepted(int.Parse(buttonText.text));
    }
}
