using UnityEngine;

namespace HourChallenge
{
    public class PageNavigator
    {
        public int Page { get; private set; } = 1;
        public int NumPages { get; private set; }
        public int NumItemsPerPage { get; private set; }

        public bool IsFirstPage => Page == 1;
        public bool IsLastPage => Page == NumPages;

        int PageWithItem(int item) => Mathf.CeilToInt((float)item / NumItemsPerPage);

        public PageNavigator(int numPages, int numItemsPerPage = 9)
        {
            NumPages = numPages;
            NumItemsPerPage = numItemsPerPage;
        }

        public void MoveNext()
        {
            if (Page >= NumPages) return;
            Page++;
        }

        public void MovePrevious()
        {
            if (Page <= 1) return;
            Page--;
        }

        public void MoveToPageWithItem(int item)
        {
            if (item == 0 || item > NumPages * NumItemsPerPage) return;
            Page = PageWithItem(item);
        }
    }
}