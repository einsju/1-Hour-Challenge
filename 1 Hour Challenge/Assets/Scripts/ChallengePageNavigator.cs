using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HourChallenge
{
    public class ChallengePageNavigator : MonoBehaviour
    {
        IList<GameObject> _pages;

        IList<GameObject> PageComponents => GetComponentsInChildren<Transform>(true).Where(go => go.name.StartsWith("Page_")).Select(go => go.gameObject).ToList();

        GameObject CurrentPage => _pages.FirstOrDefault(p => p.activeSelf);        

        void Awake() => _pages = PageComponents;

        public void OpenPage(GameObject page)
        {
            CurrentPage.SetActive(false);
            page.SetActive(true);
        }
    }
}
