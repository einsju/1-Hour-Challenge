using UnityEngine;
using UnityEngine.SceneManagement;

namespace HourChallenge.Managers
{
    public class GameManager : MonoBehaviour
    {
        const string ChallengeSceneNamePrefix = "Challenge_";

        void OnEnable()
        {
            EventManager.ChallengeAcceptedEventHandler += ChallengeAccepted;
        }

        void OnDisable()
        {
            EventManager.ChallengeAcceptedEventHandler -= ChallengeAccepted;
        }

        void ChallengeAccepted(int challengeNumber)
        {
            SceneManager.LoadScene($"{ChallengeSceneNamePrefix}{challengeNumber}");
        }
    }
}
