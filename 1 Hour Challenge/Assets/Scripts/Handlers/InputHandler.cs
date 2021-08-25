using UnityEngine;

namespace HourChallenge.Handlers
{
    public class InputHandler : MonoBehaviour
    {
        public Vector3 Position => Input.mousePosition;
        public bool Touched => Input.GetMouseButtonDown(0);
        public bool Released => Input.GetMouseButtonUp(0);
        public Vector3 LastPosition { get; private set; } = Vector3.zero;

        void Update()
        {
            if (Touched) SaveLastPosition();
        }

        void SaveLastPosition() => LastPosition = Input.mousePosition;
    }
}
