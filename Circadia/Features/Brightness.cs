using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using Circadia.Interops;

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

        private static void SetExternalBrightness(uint brightness)
        {
            User32.EnumDisplayMonitors(
                IntPtr.Zero,
                IntPtr.Zero,
                (hMonitor, hdc, ref rect, data) =>
                {
                    if (!Dxva2.GetNumberOfPhysicalMonitorsFromHMONITOR(
                        hMonitor,
                        out uint count))
                        return true;

                    var monitors = new PHYSICAL_MONITOR[count];

                    if (!Dxva2.GetPhysicalMonitorsFromHMONITOR(
                        hMonitor,
                        count,
                        monitors))
                        return true;

                    try
                    {
                        foreach (var monitor in monitors)
                        {
                            try
                            {
                                Dxva2.GetMonitorBrightness(
                                    monitor.hPhysicalMonitor,
                                    out uint min,
                                    out _,
                                    out uint max);

                                uint value = min + (brightness * (max - min) / 100);

                                Dxva2.SetMonitorBrightness(
                                    monitor.hPhysicalMonitor,
                                    value);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    finally
                    {
                        Dxva2.DestroyPhysicalMonitors(count, monitors);
                    }

                    return true;
                },
                IntPtr.Zero);
        }

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

        private static uint GetExternalBrightness()
        {
            uint result = 0;

            User32.EnumDisplayMonitors(
                IntPtr.Zero,
                IntPtr.Zero,
                (hMonitor, hdc, ref rect, data) =>
                {
                    if (!Dxva2.GetNumberOfPhysicalMonitorsFromHMONITOR(
                            hMonitor,
                            out uint count))
                        return true;

                    var monitors = new PHYSICAL_MONITOR[count];

                    if (!Dxva2.GetPhysicalMonitorsFromHMONITOR(
                            hMonitor,
                            count,
                            monitors))
                        return true;

                    try
                    {
                        foreach (var monitor in monitors)
                        {
                            if (Dxva2.GetMonitorBrightness(
                                    monitor.hPhysicalMonitor,
                                    out uint min,
                                    out uint current,
                                    out uint max))
                            {
                                result = (current - min) * 100 / (max - min);
                                return false;
                            }
                        }
                    }
                    finally
                    {
                        Dxva2.DestroyPhysicalMonitors(
                            count,
                            monitors);
                    }

                    return true;
                },
                IntPtr.Zero);

            return result;
        }
    }
}

