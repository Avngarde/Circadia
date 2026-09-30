using Circadia.Features;
using Circadia.Forms;
using Circadia.Utils;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;

namespace Circadia;

public class CircadiaApplicationContext : ApplicationContext
{
    private bool _eyeProtectionOn;
    private NotifyIcon _trayIcon;
    private SettingsValues _settings;
    
    private IBrightness _brightness;
    private ISystemTheme _theme;
    private IBlueLight _blueLight;
    
    public CircadiaApplicationContext(IBrightness brightness, IBlueLight blueLight, ISystemTheme systemTheme)
    {
        _settings = Settings.Load();

        _theme = systemTheme;
        _brightness = brightness;
        _blueLight = blueLight;
        
        var menu = new ContextMenuStrip();

        menu.Items.Add("Show Settings", null, ShowSettings);
        menu.Items.Add("Exit", null, Exit);

        _trayIcon = new NotifyIcon
        {
            Icon = new Icon("./Resources/icon.ico"),
            ContextMenuStrip = menu,
            Visible = true
        };

        if (_settings.FirstLaunch == true)
        {
            AskForAutostart();
            ShowSettings(null, null);
        }

        _settings.FirstLaunch = false;
        Settings.Save(_settings);
    }

    private void AskForAutostart()
    {
        var result = MessageBox.Show("Do you want to add Circadia to AutoStart?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.No)
            return;

        AddToAutostart();
    }

    private void AddToAutostart()
    {
        string appName = "Circadia";
        string appPath = Application.ExecutablePath;

        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(
            @"Software\Microsoft\Windows\CurrentVersion\Run", true);

        key?.SetValue(appName, appPath);        
    }
    
    private void ShowSettings(object? sender, EventArgs? e)
        => new SettingsForm(_brightness, _blueLight).ShowDialog();
    
    private void Exit(object? sender, EventArgs e)
    {
        _blueLight.TurnOff();

        _trayIcon.Visible = false;
        _trayIcon.Dispose();

        ExitThread();
    }
}