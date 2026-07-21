using System.Runtime.InteropServices;

namespace Circadia.Utils;

public class ExplorerRefresh
{
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessageTimeout(
        IntPtr hWnd,
        uint Msg,
        IntPtr wParam,
        string lParam,
        uint flags,
        uint timeout,
        out IntPtr result);

    public static void Refresh()
    {
        SendMessageTimeout(
            new IntPtr(0xffff),
            0x001A, // WM_SETTINGCHANGE
            IntPtr.Zero,
            "ImmersiveColorSet",
            2,
            1000,
            out _);
    }
}