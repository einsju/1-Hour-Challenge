using UnityEngine;

namespace HourChallenge
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] float speed = 1f;

        Vector3 Rotation => new Vector3(0, 0, -45);

        void Update() => transform.Rotate(speed * Time.deltaTime * Rotation);
    }
}
