using HourChallenge.Handlers;
using UnityEngine;

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
            SceneLoader.LoadScene($"{ChallengeSceneNamePrefix}{challengeNumber}");
        }
    }
}
