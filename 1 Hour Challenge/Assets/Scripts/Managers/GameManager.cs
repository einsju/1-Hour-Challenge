using HourChallenge.Handlers;
using HourChallenge.Storage;
using UnityEngine;

namespace HourChallenge.Managers
{
    public class GameManager : MonoBehaviour
    {
        void OnEnable()
        {
            ChallengeEventHandler.ChallengeAccepted += ChallengeAccepted;
            ChallengeEventHandler.NextChallengeAccepted += NextChallengeAccepted;
        }

        void OnDisable()
        {
            ChallengeEventHandler.ChallengeAccepted -= ChallengeAccepted;
            ChallengeEventHandler.NextChallengeAccepted -= NextChallengeAccepted;
        }

        void ChallengeAccepted(int challengeNumber)
        {
            // Check for rewarded video etc...
            Preferences.SetCurrentChallenge(challengeNumber);
            SceneLoader.LoadScene("Game");
        }

        void NextChallengeAccepted(int currentChallengeNumber)
        {
            Preferences.SetCurrentChallenge(currentChallengeNumber + 1);
            //SceneLoader.LoadScene($"{ChallengeSceneNamePrefix}{challengeNumber}");
        }
    }
}
