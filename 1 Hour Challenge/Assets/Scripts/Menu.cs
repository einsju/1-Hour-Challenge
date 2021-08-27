using HourChallenge.Handlers;
using HourChallenge.Storage;
using System.Linq;
using UnityEngine;

namespace HourChallenge
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] ChallengePageNavigator pageNavigator;

        int _currentChallengeNumber;

        ChallengeButton CurrentChallengeButton => FindObjectsOfType<ChallengeButton>().First(cb => cb.ChallengeNumber == _currentChallengeNumber);

        void Awake()
        {
            NotifyHighscore();
            SetCurrentChallenge();
        }

        void NotifyHighscore() => ScoreEventHandler.OnHighscoreLoaded(GameProgressService.GetTotalScore());

        void SetCurrentChallenge()
        {
            var currentChallenge = GameProgressService.GetCurrentChallenge();
            _currentChallengeNumber = currentChallenge != null ? currentChallenge.ChallengeNumber : 1;
            pageNavigator.OpenPageByChallenge(_currentChallengeNumber);
            CurrentChallengeButton.Activate();
        }
    }
}
