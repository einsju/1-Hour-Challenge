using UnityEngine;
using TMPro;

namespace HourChallenge
{
    [ExecuteInEditMode]
    public class ChallengeButton : MonoBehaviour
    {
        [SerializeField] TMP_Text buttonText;

        void Awake()
        {
            buttonText.text = gameObject.name;
        }
    }
}
