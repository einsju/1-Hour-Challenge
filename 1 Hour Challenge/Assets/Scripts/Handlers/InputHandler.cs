using HourChallenge.Abstractions;
using UnityEngine;

namespace HourChallenge.Handlers
{
    public class InputHandler : MonoBehaviour, IInputHandler
    {
        [SerializeField] float minimumSwipeDistance = 75f;

        Vector3 _lastPosition = Vector3.zero;

        public bool Touched => Input.GetMouseButtonDown(0);
        public bool SwipedUp => SwipeAccepted && Position.y > _lastPosition.y;
        public bool SwipedDown => SwipeAccepted && Position.y < _lastPosition.y;

        bool SwipeAccepted => Released && Mathf.Abs(Position.y - _lastPosition.y) >= minimumSwipeDistance;
        bool Released => Input.GetMouseButtonUp(0);
        Vector3 Position => Input.mousePosition;

        void Update()
        {
            if (Touched) SaveLastPosition();
        }

        void SaveLastPosition() => _lastPosition = Input.mousePosition;
    }
}
