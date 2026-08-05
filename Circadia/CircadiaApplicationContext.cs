using Circadia.Features;
using Circadia.Forms;

namespace Circadia;

public class CircadiaApplicationContext : ApplicationContext
{
    private bool _eyeProtectionOn;
    private NotifyIcon _trayIcon;
    
    private IBrightness _brightness;
    private ISystemTheme _theme;
    private SettingsValues _settings;
    
    public CircadiaApplicationContext()
    {
        _settings = Settings.Load();
        _theme = new SystemTheme();
        _brightness = new Brightness();
        
        var menu = new ContextMenuStrip();

        menu.Items.Add("Show Settings", null, ShowSettings);
        menu.Items.Add("Turn Eye Protection On", null, ToggleEyeProtection);
        menu.Items.Add("Exit", null, Exit);

        _trayIcon = new NotifyIcon
        {
            Icon = new Icon("./Resources/icon.ico"),
            ContextMenuStrip = menu,
            Visible = true
        };
    }

    private void ShowSettings(object? sender, EventArgs e)
    {
        new SettingsForm().ShowDialog();

        _settings = Settings.Load();
    }

    private void ToggleEyeProtection(object? sender, EventArgs e)
    {
        _brightness.SetBrightness(
            _eyeProtectionOn 
                ? (uint)_settings.BrightnessLight
                : (uint)_settings.BrightnessDark
        );
        _theme.SetTheme(
            _eyeProtectionOn
                ? SystemThemeOption.Light
                : SystemThemeOption.Dark
        );

        var menuItem = sender as ToolStripMenuItem;
        _eyeProtectionOn = !_eyeProtectionOn;
        
        menuItem.Text = _eyeProtectionOn ? "Turn Eye Protection Off" : "Turn Eye Protection On";
    }
    
    private void Exit(object? sender, EventArgs e)
    {
        _trayIcon.Visible = false;
        _trayIcon.Dispose();
        ExitThread();
    }
    private void ChangeTheme(object? sender, EventArgs e)
    {
        SystemTheme systemTheme = new();

        var theme = systemTheme.GetTheme();

        systemTheme.SetTheme(
            theme == SystemThemeOption.Light 
                ? SystemThemeOption.Dark 
                : SystemThemeOption.Light
        );
    }
}