using Xamarin.UITest;

namespace XamarinUITestPopSample.UITests.Utility
{
    public static class NativeElementNames
    {
        public static string Label
        {
            get
            {
                if (AppInitializer.Platform == Platform.Android)
                    return "FormsTextView";
                return "UILabel";
            }

        }
        public static string TabBar
        {
            get
            {
                if (AppInitializer.Platform == Platform.Android)
                    return "BottomNavigationMenuView";
                return "UITabBar";
            }
        }
    }
}
