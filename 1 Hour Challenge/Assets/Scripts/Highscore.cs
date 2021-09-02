using HourChallenge.Storage;
using TMPro;
using UnityEngine;

namespace HourChallenge
{
    public class Highscore : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;

        void Start() => scoreText.text = $"YOUR SCORE: {GameProgressService.GetTotalScore()}";
    }
}
