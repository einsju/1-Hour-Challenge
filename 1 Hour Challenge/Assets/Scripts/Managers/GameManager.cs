using HourChallenge.Handlers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HourChallenge.Managers
{
    public class GameManager : MonoBehaviour
    {
        const string ChallengeSceneNamePrefix = "Challenge_";

        void OnEnable()
        {
            ChallengeEventHandler.ChallengeAccepted += ChallengeAccepted;
        }

        void OnDisable()
        {
            ChallengeEventHandler.ChallengeAccepted -= ChallengeAccepted;
        }

        void ChallengeAccepted(int challengeNumber)
        {
            SceneManager.LoadScene($"{ChallengeSceneNamePrefix}{challengeNumber}");
        }
    }
}
