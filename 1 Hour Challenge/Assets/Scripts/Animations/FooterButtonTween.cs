using UnityEngine;

namespace HourChallenge
{
    public class FooterButtonTween : MonoBehaviour
    {
        Vector3 targetScale => new Vector3(1.05f, 1.05f, 1.05f);
        
        void Start() => transform.LeanScale(targetScale, 0.5f).setLoopPingPong();
    }
}
