using UnityEngine;

namespace HourChallenge.Animations
{
    public class FooterTween : MonoBehaviour
    {
        [SerializeField] float duration = 1f;
        
        void Awake() => transform.position = new Vector2(transform.position.x, transform.position.y -100f);

        void Start() => transform.LeanMoveY(0f, duration).setEaseInOutBounce();
    }
}
