using NUnit.Framework;

namespace HourChallenge
{
    public class PageNavigatorTests
    {
        PageNavigator PageNavigator => new PageNavigator(7);

        [Test]
        public void Should_Open_Next_Page_On_MoveNext()
        {
            var pageNavigator = PageNavigator;
            
            pageNavigator.MoveNext();

            Assert.IsTrue(pageNavigator.Page == 2);
        }

        [Test]
        public void Should_Open_Previous_Page_On_MovePrevious()
        {
            var pageNavigator = PageNavigator;

            pageNavigator.MoveNext();
            pageNavigator.MovePrevious();

            Assert.IsTrue(pageNavigator.Page == 1);
        }

        [Test]
        public void Should_Open_Page_On_MoveToPage()
        {
            var pageNavigator = PageNavigator;
            var page = 4;

            pageNavigator.MoveToPage(page);

            Assert.IsTrue(pageNavigator.Page == page);
        }

        [Test]
        public void Should_Not_Open_Next_Page_On_MoveNext_From_Last_Page()
        {
            var pageNavigator = PageNavigator;

            for (var i = 0; i < pageNavigator.NumPages; i++)
                pageNavigator.MoveNext();

            pageNavigator.MoveNext();

            Assert.IsTrue(pageNavigator.Page == pageNavigator.NumPages);
        }

        [Test]
        public void Should_Not_Open_Previous_Page_On_MovePrevious_From_First_Page()
        {
            var pageNavigator = PageNavigator;

            pageNavigator.MovePrevious();

            Assert.IsTrue(pageNavigator.Page == 1);
        }

        [TestCase(0)]
        [TestCase(8)]
        public void Should_Not_Open_Page_Outside_Boundaries_On_MoveToPage(int page)
        {
            var pageNavigator = PageNavigator;

            pageNavigator.MoveToPage(page);

            Assert.IsFalse(pageNavigator.Page == page);
        }
    }
}
