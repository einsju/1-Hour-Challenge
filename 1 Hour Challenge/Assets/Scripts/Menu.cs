using HourChallenge.Handlers;
using System.Linq;
using TMPro;
using UnityEngine;

namespace HourChallenge
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] TMP_Text score;
        [SerializeField] ChallengePageNavigator pageNavigator;

        ChallengeButton CurrentChallengeButton => FindObjectsOfType<ChallengeButton>().First(cb => cb.ChallengeNumber == 1);

        void Awake() => pageNavigator = GetComponent<ChallengePageNavigator>();

        //void SetHighscore() => highscore.text = $"SCORE: {122}";

        void Start() => SetCurrentChallenge();

        void SetCurrentChallenge()
        {
            ScoreEventHandler.OnHighscoreLoaded(0);
            //pageNavigator.OpenPageByChallenge(1);
            //CurrentChallengeButton.Activate();
        }
    }
}
