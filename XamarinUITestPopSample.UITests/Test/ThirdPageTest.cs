using System;
using NUnit.Framework;
using Xamarin.UITest;
using XamarinUITestPopSample.UITests.Base;
using XamarinUITestPopSample.UITests.Page;
using XamarinUITestPopSample.UITests.Utility;

namespace XamarinUITestPopSample.UITests.Test
{
    [Parallelizable]
    [TestFixture(Platform.Android,AndroidPhysicalDevices.Galaxy)]
    [TestFixture(Platform.iOS, iPhone11ProMax.OS_13_2_2)]
    public class ThirdPageTest : TestBase
    {
        public ThirdPageTest(Platform platform, string device) : base(platform, device)
        {

        }
        [Test]
        public void ValideEntry()
        {
            new ThirdPage(app)
               .ValidateEntry();
        }
        [Test]
        public void OpenPushModal()
        {
            new ThirdPage(app)
               .OpenPushModalPage();
        }
    }
}
