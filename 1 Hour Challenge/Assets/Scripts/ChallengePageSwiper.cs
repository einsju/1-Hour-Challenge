using HourChallenge.Handlers;
using UnityEngine;

namespace HourChallenge
{
    public class ChallengePageSwiper : MonoBehaviour
    {
        [SerializeField] float minimumDragDistance = 75f;

        ChallengePageNavigator _pageNavigator;
        InputHandler _inputHandler;

        bool SwipeAccepted => Mathf.Abs(_inputHandler.Position.y - _inputHandler.LastPosition.y) >= minimumDragDistance;
        bool Next => _inputHandler.Position.y > _inputHandler.LastPosition.y;

        void Awake()
        {
            _pageNavigator = GetComponent<ChallengePageNavigator>();
            _inputHandler = GetComponent<InputHandler>();
        }

        void Update()
        {
            if (_inputHandler.Released && SwipeAccepted) Navigate();
        }

        void Navigate()
        {
            if (Next)
            {
                OpenNextPage();
                return;
            }

            OpenPreviousPage();
        }

        void OpenNextPage() => _pageNavigator.Next();
        void OpenPreviousPage() => _pageNavigator.Previous();
    }
}
