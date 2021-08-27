using HourChallenge.Abstractions;
using UnityEngine;

namespace HourChallenge
{
    public class ChallengePageSwiper : MonoBehaviour
    {
        ChallengePageNavigator _pageNavigator;
        IInputHandler _inputHandler;

        void Awake()
        {
            _pageNavigator = GetComponent<ChallengePageNavigator>();
            _inputHandler = GetComponent<IInputHandler>();
        }

        void Update()
        {
            if (_inputHandler.SwipedUp) OpenNextPage();
            if (_inputHandler.SwipedDown) OpenPreviousPage();
        }

        void OpenNextPage() => _pageNavigator.Next();
        void OpenPreviousPage() => _pageNavigator.Previous();
    }
}
