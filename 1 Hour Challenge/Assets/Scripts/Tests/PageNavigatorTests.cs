using NUnit.Framework;
using UnityEngine;

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
        public void Should_Open_Page_On_MoveToPageWithItem()
        {
            var pageNavigator = PageNavigator;
            var item = 12;
            var page = Mathf.CeilToInt(item / pageNavigator.NumItemsPerPage);

            pageNavigator.MoveToPageWithItem(item);

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
        [TestCase(64)]
        public void Should_Not_Open_Page_Outside_Boundaries_On_MoveToPageWithItem(int item)
        {
            var pageNavigator = PageNavigator;
            var page = pageNavigator.Page;

            pageNavigator.MoveToPageWithItem(item);

            Assert.IsTrue(pageNavigator.Page == page);
        }
    }
}
