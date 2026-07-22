using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using Circadia.Interops;
using Circadia.Utils;

namespace Circadia.Features
{
    public class Brightness : IBrightness
    {
        public uint GetBrightness()
        {
            var laptopBrightness = GetLaptopBrightness();
            var screensBrightness = GetExternalBrightness();

            if (laptopBrightness == screensBrightness)
                return laptopBrightness;
            else if (laptopBrightness == 0 && screensBrightness > 0)
                return screensBrightness;
            else
                return laptopBrightness;
        }

        public void SetBrightness(uint brightness)
        {
            var brightClamped = Math.Clamp(brightness, 0, 100);

            SetExternalBrightness(brightClamped);
            SetLaptopBrightness(brightClamped);
        }

        private static void SetExternalBrightness(uint brightness) =>
            BrightnessWinInteropFacade.MonitorEnumProcDelegateSetBrightness(brightness);

        private static uint GetExternalBrightness() => 
            BrightnessWinInteropFacade.MonitorEnumProcDelegateGetBrightness();

        private static void SetLaptopBrightness(uint brightness)
        {
            brightness = Math.Min(brightness, 100);

            var scope = new ManagementScope(@"\\.\root\wmi");

            using var methods = new ManagementClass(
                scope,
                new ManagementPath("WmiMonitorBrightnessMethods"),
                null);

            foreach (ManagementObject monitor in methods.GetInstances())
            {
                monitor.InvokeMethod(
                    "WmiSetBrightness",
                    new object[]
                    {
                1,
                (byte)brightness
                    });
            }
        }

        private static uint GetLaptopBrightness()
        {
            try
            {
                var scope = new ManagementScope(@"\\.\root\wmi");

                using var brightness =
                    new ManagementObjectSearcher(
                        scope,
                        new ObjectQuery(
                            "SELECT CurrentBrightness FROM WmiMonitorBrightness"))
                    .Get();

                foreach (ManagementObject monitor in brightness)
                {
                    return Convert.ToUInt32(monitor["CurrentBrightness"]);
                }
            }
            catch { }

            return 0;
        }
    }
}

