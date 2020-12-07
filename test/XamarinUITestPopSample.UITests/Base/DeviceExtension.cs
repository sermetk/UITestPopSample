using System;
using System.Linq;
using Xamarin.UITest;
using XamarinUITestPopSample.UITests.Utility;

namespace XamarinUITestPopSample.UITests.Base
{
    public static class DeviceExtension
    {
        public static string GetiOSDeviceID(string simulatorName)
        {
            if (!TestEnvironment.Platform.Equals(TestPlatform.Local))
            {
                return string.Empty;
            }
            var simulators = new TerminalRunner().GetListOfiOSSimulators();
            var simulator = (from sim in simulators
                             where sim.Name.Equals(simulatorName)
                             select sim).FirstOrDefault();
            if (simulator == null)
            {
                throw new ArgumentException("Could not find a device identifier for '" + simulatorName + "'.", nameof(simulatorName));
            }
            return simulator.GUID;
        }

        public static string GetAndroidDevice(string simulatorName)
        {
            if (!TestEnvironment.Platform.Equals(TestPlatform.Local))
            {
                return string.Empty;
            }
            var emulators = new TerminalRunner().GetListAndroidSimulators();
            var emulator = (from emu in emulators
                            where emu.Equals(simulatorName)
                            select emu).FirstOrDefault();

            if (emulators == null && emulator == string.Empty)
            {
                throw new ArgumentException("Could not find a device identifier for Android'");
            }
            return emulator;
        }
    }
}
