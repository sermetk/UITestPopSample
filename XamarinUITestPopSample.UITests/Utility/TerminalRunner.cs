using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace XamarinUITestPopSample.UITests.Utility
{
    public class TerminalRunner
    {
        static string[] GetInstrumentsOutput()
        {
            var result = GetTerminalResult("/usr/bin/xcrun", "instruments -s devices");
            var lines = result.Split('\n');
            return lines;
        }
        static string[] GetAdbOutput()
        {
            var result = GetTerminalResult($"/Users/{Environment.UserName}/Library/Developer/Xamarin/android-sdk-macosx/platform-tools/adb", "devices");
            var lines = result.Split('\n');
            return lines;
        }
        static string GetTerminalResult(string filePath, string command)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = filePath,
                Arguments = command,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                StandardOutputEncoding = Encoding.UTF8
            };
            var proc = new Process
            {
                StartInfo = startInfo
            };
            proc.Start();
            var result = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            return result;
        }

        public iOSSimulatorModel[] GetListOfiOSSimulators()
        {
            var simulators = new List<iOSSimulatorModel>();
            var lines = GetInstrumentsOutput();
            foreach (var line in lines)
            {
                var sim = new iOSSimulatorModel(line);
                if (sim.IsValid())
                {
                    simulators.Add(sim);
                }
            }
            return simulators.ToArray();
        }

        public string[] GetListAndroidSimulators()
        {
            var emulators = new List<string>();
            var lines = GetAdbOutput();
            foreach (var line in lines)
            {
                if (line != string.Empty & !line.Contains("List"))
                    emulators.Add(line.Replace("\tdevice", string.Empty));
            }
            return emulators.ToArray();
        }
    }
}
