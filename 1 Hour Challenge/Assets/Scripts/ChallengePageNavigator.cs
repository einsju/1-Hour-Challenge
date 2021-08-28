using HourChallenge.Storage;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HourChallenge
{
    public class ChallengePageNavigator : MonoBehaviour
    {
        [SerializeField] GameObject previousButton;
        [SerializeField] GameObject nextButton;

        IList<GameObject> PageComponents => GetComponentsInChildren<Transform>(true).Where(go => go.name.StartsWith("Page_")).Select(go => go.gameObject).ToList();
        GameObject CurrentPage => _pages[_pageNavigator.Page - 1];

        GameObject[] _pages;
        PageNavigator _pageNavigator;

        void Awake()
        {
            _pages = PageComponents.ToArray();
            _pageNavigator = new PageNavigator(_pages.Length);
            OpenPageByChallenge();
        }

        public void Previous()
        {
            Deactivate(CurrentPage);
            _pageNavigator.MovePrevious();
            Activate(CurrentPage);
            HandleNavigationButtonState();
        }

        public void Next()
        {
            Deactivate(CurrentPage);
            _pageNavigator.MoveNext();
            Activate(CurrentPage);
            HandleNavigationButtonState();
        }

        public void OpenPageByChallenge()
        {
            var currentChallenge = Preferences.CurrentChallenge;
            if (currentChallenge <= _pageNavigator.NumItemsPerPage) return;
            Deactivate(CurrentPage);
            _pageNavigator.MoveToPageWithItem(currentChallenge);
            Activate(CurrentPage);
            HandleNavigationButtonState();
        }

        void Activate(GameObject page) => page.SetActive(true);
        void Deactivate(GameObject page) => page.SetActive(false);

        void HandleNavigationButtonState()
        {
            previousButton.SetActive(!_pageNavigator.IsFirstPage);
            nextButton.SetActive(!_pageNavigator.IsLastPage);
        }
    }
}
