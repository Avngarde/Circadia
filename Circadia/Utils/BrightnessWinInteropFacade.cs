using Circadia.Features;
using Circadia.Forms.Fonts;
using Circadia.Interops;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circadia.Utils
{
    public static class BrightnessWinInteropFacade
    {
        public static uint MonitorEnumProcDelegateGetBrightness()
        {
            uint brightness = 0;

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
                                brightness = (current - min) * 100 / (max - min);
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

            return brightness;
        }

        public static void MonitorEnumProcDelegateSetBrightness(uint brightness)
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
                IntPtr.Zero
            );
        }
    }
}
