using Circadia.Features;
using Circadia.Forms.Fonts;
using Circadia.Interops;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circadia.Utils
{
    public static class BlueLightWinInteropFacade
    {
        public static void SetBlueLightGamma(uint intensity)
        {
            // For some weird reason, SetDeviceGammaRamp does not work for values above 60
            intensity = Math.Clamp(intensity, 0, 60); 

            RAMP ramp = new RAMP
            {
                Red = new ushort[256],
                Green = new ushort[256],
                Blue = new ushort[256]
            };

            double p = intensity / 100.0;
            double gRed = 1.0;
            double gGreen = 1.0 + (p * 0.8);
            double gBlue = 1.0 + (p * 2.0);
            double maxGreen = 1.0 - (p * 0.45);
            double maxBlue = 1.0 - (p * 0.80);

            for (int i = 0; i < 256; i++)
            {
                double normalized = i / 255.0;
                double rVal = Math.Pow(normalized, gRed);
                double gVal = Math.Pow(normalized, gGreen) * maxGreen;
                double bVal = Math.Pow(normalized, gBlue) * maxBlue;

                ramp.Red[i] = (ushort)(rVal * 65535.0);
                ramp.Green[i] = (ushort)(gVal * 65535.0);
                ramp.Blue[i] = (ushort)(bVal * 65535.0);
            }

            IntPtr dc = User32.GetDC(IntPtr.Zero);
            
            Gdi32.SetDeviceGammaRamp(dc, ref ramp);
            User32.ReleaseDC(IntPtr.Zero, dc);
        }
    }
}