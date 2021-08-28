using UnityEngine.SceneManagement;
using UnityEngine;

namespace HourChallenge
{
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadScene(string name) => SceneManager.LoadScene(name);
    }
}
