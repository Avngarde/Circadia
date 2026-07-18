namespace Circadia;

public class CircadiaApplicationContext : ApplicationContext
{
    private NotifyIcon _trayIcon;

    public CircadiaApplicationContext()
    {
        var menu = new ContextMenuStrip();
        menu.Items.Add("Exit", null, Exit);

        _trayIcon = new NotifyIcon
        {
            Icon = new Icon("./Resources/icon.ico"),
            ContextMenuStrip = menu,
            Visible = true
        };
    }

    private void Exit(object? sender, EventArgs e)
    {
        _trayIcon.Visible = false;
        _trayIcon.Dispose();
        ExitThread();
    }
}