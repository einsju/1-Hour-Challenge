using HourChallenge.Handlers;
using TMPro;
using UnityEngine;

namespace HourChallenge.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;

        void OnEnable() => ScoreEventHandler.ScoreLoaded += ScoreLoaded;
        void OnDisable() => ScoreEventHandler.ScoreLoaded -= ScoreLoaded;

        void ScoreLoaded(int score) => scoreText.text = $"SCORE: {score}";
    }
}
