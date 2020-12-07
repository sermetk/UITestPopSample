using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using XamarinUITestPopSample.UITests.Base;

namespace XamarinUITestPopSample.UITests.Page
{  
    public class MainPage
    {
        private readonly IApp App;
        public MainPage(IApp app)
        {
            App = app;
        }
        public void NavigeTabs()
        {
            for (int i = 1; i < 4; i++)
            {
                App.NavigateToMenuItem(i);
                App.Screenshot($"Tab{i}");
            }
        }
    }
}
