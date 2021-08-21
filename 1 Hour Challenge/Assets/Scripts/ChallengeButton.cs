using UnityEngine;
using TMPro;

namespace HourChallenge
{
    [ExecuteAlways]
    public class ChallengeButton : MonoBehaviour
    {
        [SerializeField] TMP_Text buttonText;

        bool TextIsNumber => int.TryParse(gameObject.name, out _);

        void Awake() => SetChallengeText();

        void SetChallengeText()
        {
            if (!TextIsNumber) return;
            buttonText.text = gameObject.name;
        }
    }
}
