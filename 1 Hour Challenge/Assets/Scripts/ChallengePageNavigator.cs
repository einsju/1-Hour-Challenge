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
        GameObject PreviousPage(GameObject fromPage) => _pages[_pages.IndexOf(fromPage) - 1];
        GameObject NextPage(GameObject fromPage) => _pages[_pages.IndexOf(fromPage) + 1];

        bool IsFirstPage => CurrentPage == _pages.First();
        bool IsLastPage => CurrentPage == _pages.Last();

        void Awake() => _pages = PageComponents;

        public void Previous()
        {
            if (IsFirstPage) return;
            var current = CurrentPage;
            Deactivate(current);
            Activate(PreviousPage(current));
        }

        public void Next()
        {
            if (IsLastPage) return;
            var current = CurrentPage;
            Deactivate(current);
            Activate(NextPage(current));
        }

        void Activate(GameObject page) => page.SetActive(true);
        void Deactivate(GameObject page) => page.SetActive(false);
    }
}
