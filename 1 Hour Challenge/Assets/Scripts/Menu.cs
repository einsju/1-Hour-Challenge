using HourChallenge.Handlers;
using System.Linq;
using UnityEngine;

namespace HourChallenge
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] ChallengePageNavigator pageNavigator;

        ChallengeButton CurrentChallengeButton => FindObjectsOfType<ChallengeButton>().First(cb => cb.ChallengeNumber == 1);

        void Awake() => pageNavigator = GetComponent<ChallengePageNavigator>();

        void Start() => SetCurrentChallenge();

        void SetCurrentChallenge()
        {
            ScoreEventHandler.OnHighscoreLoaded(158);
            //pageNavigator.OpenPageByChallenge(1);
            //CurrentChallengeButton.Activate();
        }
    }
}
