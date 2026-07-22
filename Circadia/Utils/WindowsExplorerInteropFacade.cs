using Circadia.Interops;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circadia.Utils
{
    public static class WindowsExplorerInteropFacade
    {
        public static void RefreshWindowsExplorer()
        {
            User32.SendMessageTimeout(
                new IntPtr(0xffff),
                0x001A, // WM_SETTINGCHANGE
                IntPtr.Zero,
                "ImmersiveColorSet",
                2,
                1000,
                out _);
        }
    }
}
