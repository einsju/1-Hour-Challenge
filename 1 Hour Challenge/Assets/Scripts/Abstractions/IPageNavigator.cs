namespace HourChallenge.Abstractions
{
    public interface IPageNavigator
    {
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
        int NumItemsPerPage { get; }
        int NumPages { get; }
        int Page { get; }

        void MoveNext();
        void MovePrevious();
        void MoveToPageWithItem(int item);
    }
}