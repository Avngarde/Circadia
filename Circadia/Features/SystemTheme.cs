using System.Runtime.InteropServices;
using Circadia.Utils;
using Microsoft.Win32;

namespace Circadia.Features;

public class SystemTheme : ISystemTheme
{
    private const string _key =
        @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
    
    public void SetTheme(SystemThemeOption theme)
    {
        using RegistryKey registryKey =
            Registry.CurrentUser.CreateSubKey(_key);
        
        registryKey.SetValue("AppsUseLightTheme", theme == SystemThemeOption.Light, 
            RegistryValueKind.DWord);
        registryKey.SetValue("SystemUsesLightTheme", theme == SystemThemeOption.Light, 
            RegistryValueKind.DWord);
        
        User32.RefreshWindowsExplorer();
    }

    public SystemThemeOption GetTheme()
    {
        using var key = Registry.CurrentUser.OpenSubKey(_key);

        var appsTheme = (int)(key?.GetValue("AppsUseLightTheme") ?? 1);
        var systemTheme = (int)(key?.GetValue("SystemUsesLightTheme") ?? 1);

        if (appsTheme == 0 && systemTheme == 0) 
            return SystemThemeOption.Dark;
        
        return SystemThemeOption.Light;
    }
}