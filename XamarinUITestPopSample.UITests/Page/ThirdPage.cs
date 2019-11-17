using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using XamarinUITestPopSample.UITests.Base;

namespace XamarinUITestPopSample.UITests.Page
{
    public class ThirdPage
    {
        private readonly IApp App;

        #region Elements
        private readonly Func<AppQuery, AppQuery> Entry = c => c.Marked("Entry_AutomationId");
        private readonly Func<AppQuery, AppQuery> EntryButton = c => c.Marked("EntryButton_AutomationId");
        private readonly Func<AppQuery, AppQuery> Button = c => c.Marked("PushModalButton_AutomationId");
        #endregion

        #region WaitForElements
        private readonly Func<AppQuery, AppQuery> EntryLabel = c => c.Marked("EntryLabel_AutomationId");
        private readonly Func<AppQuery, AppQuery> PushModalPage = c => c.Marked("PushModalPage_AutomationId");
        
        #endregion
        public ThirdPage(IApp app)
        {
            App = app;
            App.NavigateToMenuItem(3);
        }
        public void OpenPushModalPage()
        {
            App.TapAndWait(Button, PushModalPage);
        }

        public void ValidateEntry()
        {
            App.EnterTextAndWait(Entry, "Test", EntryButton, EntryLabel);
        }
    }
}
