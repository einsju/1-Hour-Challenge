using HourChallenge.Handlers;
using TMPro;
using UnityEngine;

namespace HourChallenge.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;

        void OnEnable() => ScoreEventHandler.HighscoreLoaded += HighscoreLoaded;
        void OnDisable() => ScoreEventHandler.HighscoreLoaded -= HighscoreLoaded;

        void HighscoreLoaded(int score) => scoreText.text = $"HIGHSCORE: {score}";
    }
}
