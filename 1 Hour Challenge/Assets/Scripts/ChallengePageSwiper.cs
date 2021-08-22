using UnityEngine;

namespace HourChallenge
{
    public class ChallengePageSwiper : MonoBehaviour
    {
        [SerializeField] float minimumDragDistance = 75f;
        [SerializeField] ChallengePageNavigator pageNavigator;
        
        Vector2 _lastPosition = Vector2.zero;

        bool SwipeAccepted => Mathf.Abs(Input.mousePosition.y - _lastPosition.y) >= minimumDragDistance;
        bool Next => Input.mousePosition.y > _lastPosition.y;

        bool Touched => Input.GetMouseButtonDown(0);
        bool Released => Input.GetMouseButtonUp(0);

        void Update()
        {
            if (Touched) SaveLastPosition();
            if (Released && SwipeAccepted) Navigate();
        }

        void SaveLastPosition() => _lastPosition = Input.mousePosition;

        void Navigate()
        {
            if (Next)
            {
                OpenNextPage();
                return;
            }

            OpenPreviousPage();
        }

        void OpenNextPage() => pageNavigator.Next();
        void OpenPreviousPage() => pageNavigator.Previous();
    }
}
