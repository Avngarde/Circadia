using System.Runtime.InteropServices;
using Circadia.Infrastructure;
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
        
        ExplorerRefresh.Refresh();
    }
}