using NUnit.Framework;
using System;
using Xamarin.UITest;

namespace XamarinUITestPopSample.UITests.Base
{
    public class TestBase
    {
        public IApp app;
        public Platform Platform;
        private readonly string Simulator;
        private readonly bool Reset;
        protected bool OnAndroid => AppInitializer.Platform == Platform.Android;        protected bool OniOS => AppInitializer.Platform == Platform.iOS;
        public TestBase(Platform platform, string simulator, bool reset = false)
        {
            Simulator = simulator;
            Platform = platform;
            Reset = reset;
        }
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(Platform, Simulator, Reset);
        }
    }
}
