using Circadia.Features;
using Circadia.Forms;

namespace Circadia;

public class CircadiaApplicationContext : ApplicationContext
{
    private NotifyIcon _trayIcon;

    public CircadiaApplicationContext()
    {
        var menu = new ContextMenuStrip();

        menu.Items.Add("Show Settings", null, ShowSettings);
        menu.Items.Add("ChangeTheme", null, ChangeTheme);
        menu.Items.Add("GetBrightness", null, GetBrightness);
        menu.Items.Add("SetBrightnessTo50", null, SetBrightnessTo50);
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
        new SettingsForm().Show();
    }

    private void SetBrightnessTo50(object? sender, EventArgs e)
    {
        Brightness brightness = new();

        brightness.SetBrightness(50);
    }

    private void GetBrightness(object? sender, EventArgs e)
    {
        Brightness brightness = new();

        var b = brightness.GetBrightness();

        MessageBox.Show(b.ToString());
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