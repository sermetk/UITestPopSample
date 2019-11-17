using Xamarin.UITest;
using XamarinUITestPopSample.UITests.Utility;

namespace XamarinUITestPopSample.UITests.Base
{
    public static class NavigationExtensions
    {
        public static void NavigateToMenuItem(this IApp app, int menuIndex)
        {
            app.Tap(c => c.Class(NativeElementNames.TabBar).Child(menuIndex));
        }
    }
}
