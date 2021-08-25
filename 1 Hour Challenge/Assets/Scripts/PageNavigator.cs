namespace HourChallenge
{
    public class PageNavigator
    {
        public int Page { get; private set; } = 1;
        public int NumPages { get; private set; }

        public bool IsFirstPage => Page == 1;
        public bool IsLastPage => Page == NumPages;

        public PageNavigator(int numPages) => NumPages = numPages;

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

        public void MoveToPage(int page)
        {
            if (page < 1 || page > NumPages) return;
            Page = page;
        }
    }
}