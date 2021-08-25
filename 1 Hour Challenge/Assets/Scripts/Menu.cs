using System.Linq;
using TMPro;
using UnityEngine;

namespace HourChallenge
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] TMP_Text highscore;
        [SerializeField] ChallengePageNavigator pageNavigator;

        ChallengeButton CurrentChallengeButton => FindObjectsOfType<ChallengeButton>().First(cb => cb.ChallengeNumber == 1);

        void Awake() => SetHighscore();

        void SetHighscore() => highscore.text = $"Score: {122}";

        void Start() => SetCurrentChallenge();

        void SetCurrentChallenge()
        {
            pageNavigator.OpenPageByChallenge(1);
            CurrentChallengeButton.Activate();
        }
    }
}
