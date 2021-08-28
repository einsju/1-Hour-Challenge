using HourChallenge.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HourChallenge
{
    public class ChallengePageNavigator : MonoBehaviour
    {
        [SerializeField] GameObject previousButton;
        [SerializeField] GameObject nextButton;
        [SerializeField] float animationDuration = 0.2f;

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

        public void Previous() => StartCoroutine(MovePreviousWithAnimation());

        IEnumerator MovePreviousWithAnimation()
        {
            StartCoroutine(PageTransition(Vector3.one, Vector3.zero));
            yield return new WaitForSeconds(animationDuration);
            Deactivate(CurrentPage);
            _pageNavigator.MovePrevious();
            Activate(CurrentPage);
            StartCoroutine(PageTransition(Vector3.zero, Vector3.one));
            HandleNavigationButtonState();
        }

        public void Next() => StartCoroutine(MoveNextWithAnimation());

        IEnumerator MoveNextWithAnimation()
        {
            StartCoroutine(PageTransition(Vector3.one, Vector3.zero));
            yield return new WaitForSeconds(animationDuration);
            Deactivate(CurrentPage);
            _pageNavigator.MoveNext();
            Activate(CurrentPage);
            StartCoroutine(PageTransition(Vector3.zero, Vector3.one));
            HandleNavigationButtonState();
        }

        IEnumerator PageTransition(Vector3 from, Vector3 to)
        {
            CurrentPage.transform.localScale = from;
            CurrentPage.LeanScale(to, animationDuration);
            yield return new WaitForSeconds(animationDuration);
            CurrentPage.transform.localScale = Vector3.one;
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
