using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HourChallenge
{
    public class ChallengePageNavigator : MonoBehaviour
    {
        [SerializeField] GameObject previousButton;
        [SerializeField] GameObject nextButton;
        
        IList<GameObject> _pages;

        IList<GameObject> PageComponents => GetComponentsInChildren<Transform>(true).Where(go => go.name.StartsWith("Page_")).Select(go => go.gameObject).ToList();

        GameObject CurrentPage => _pages.FirstOrDefault(p => p.activeSelf);
        GameObject PreviousPage(GameObject fromPage) => _pages[_pages.IndexOf(fromPage) - 1];
        GameObject NextPage(GameObject fromPage) => _pages[_pages.IndexOf(fromPage) + 1];

        GameObject PageWithChallenge(int challengeNumber) => _pages[Mathf.CeilToInt(challengeNumber / 9f) - 1];

        bool IsFirstPage => CurrentPage == _pages.First();
        bool IsLastPage => CurrentPage == _pages.Last();

        void Awake() => _pages = PageComponents;

        public void Previous()
        {
            if (IsFirstPage) return;
            var current = CurrentPage;
            Deactivate(current);
            Activate(PreviousPage(current));
            HandleNavigationButtonState();
        }

        public void Next()
        {
            if (IsLastPage) return;
            var current = CurrentPage;
            Deactivate(current);
            Activate(NextPage(current));
            HandleNavigationButtonState();
        }

        public void OpenPageByChallenge(int challengeNumber)
        {
            if (challengeNumber <= 9) return;
            Deactivate(CurrentPage);
            Activate(PageWithChallenge(challengeNumber));
            HandleNavigationButtonState();
        }

        void Activate(GameObject page) => page.SetActive(true);
        void Deactivate(GameObject page) => page.SetActive(false);

        void HandleNavigationButtonState()
        {
            previousButton.SetActive(!IsFirstPage);
            nextButton.SetActive(!IsLastPage);
        }
    }
}
