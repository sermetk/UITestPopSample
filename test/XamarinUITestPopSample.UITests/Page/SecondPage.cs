using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using XamarinUITestPopSample.UITests.Base;

namespace XamarinUITestPopSample.UITests.Page
{
    public class SecondPage
    {
        private readonly IApp App;
        #region Elements
        private readonly Func<AppQuery, AppQuery> FirstCarousel = c => c.Marked("Baboon");
        private readonly Func<AppQuery, AppQuery> SecondCarousel = c => c.Marked("Capuchin Monkey");
        #endregion

        #region Actions
        Action swipeToLeft;
        Action swipeToRight;
        #endregion
        public SecondPage(IApp app)
        {
            App = app;
            App.NavigateToMenuItem(2);
        }

        public void SwipePages()
        {
            swipeToRight = () => App.SwipeRightToLeft(FirstCarousel, swipeSpeed: 3000);
            swipeToLeft = () => App.SwipeLeftToRight(SecondCarousel, swipeSpeed: 3000);
            App.TaskAndWait(swipeToRight, SecondCarousel);
            App.TaskAndWait(swipeToLeft, FirstCarousel);
        }
    }
}
