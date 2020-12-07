using System;
using System.Diagnostics;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using XamarinUITestPopSample.UITests.Base;

namespace XamarinUITestPopSample.UITests
{
    public static class AppInitializer
    {
        private const string packageName = "com.companyname.XamarinUITestPopSample";
        private static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("Platform is not set.");
                return platform.Value;
            }
            set
            {
                platform = value;
            }
        }

        public static IApp StartApp(Platform platform, string simulator, bool resetDevice = false)
        {
            Platform = platform;
            if (platform == Platform.Android)
            {
                if (resetDevice)
                    ResetAndroidEmulator();
                return ConfigureApp
                    .Android
                    .DeviceSerial(DeviceExtension.GetAndroidDevice(simulator))
                    .InstalledApp(packageName)
                    .StartApp();
            }
            try
            {
                if (resetDevice)
                    ResetiOSSimulator(simulator);
                return ConfigureApp
                    .iOS
                    .DeviceIdentifier(DeviceExtension.GetiOSDeviceID(simulator))
                    .InstalledApp(packageName)
                    .StartApp();
            }
            catch (Exception ex)
            {
                Console.WriteLine("********Error" + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        static void ResetAndroidEmulator()
        {
            if (TestEnvironment.Platform.Equals(TestPlatform.Local))
            {
                var eraseProcess = Process.Start($"/Users/{Environment.UserName}/Library/Developer/Xamarin/android-sdk-macosx/platform-tools/adb", $"shell pm uninstall {packageName}");
                eraseProcess.WaitForExit();
            }
        }

        static void ResetiOSSimulator(string iOSSimulator)
        {
            if (TestEnvironment.Platform.Equals(TestPlatform.Local))
            {
                var deviceId = DeviceExtension.GetiOSDeviceID(iOSSimulator);

                if (string.IsNullOrEmpty(deviceId))
                    throw new ArgumentException($"No simulator found with device name [{iOSSimulator}]", iOSSimulator);

                var shutdownProcess = Process.Start("xcrun", string.Format("simctl shutdown {0}", deviceId));
                shutdownProcess.WaitForExit();
                var eraseProcess = Process.Start("xcrun", string.Format("simctl erase {0}", deviceId));
                eraseProcess.WaitForExit();
            }
        }
    }
}
