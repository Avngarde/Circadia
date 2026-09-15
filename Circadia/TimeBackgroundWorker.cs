using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Circadia.Features;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Circadia;

public class TimeBackgroundWorker : BackgroundService
{
    private IBrightness _brightness;
    private ISystemTheme _theme;
    private IBlueLight _blueLight;

    public TimeBackgroundWorker()
    {
        _theme = new SystemTheme();
        _brightness = new Brightness();
        _blueLight = new BlueLight();    
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer (TimeSpan.FromMinutes(1));

        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            try 
            {
                CheckTime();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to change theme automatically", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void CheckTime()
    {
        var settings = Settings.Load();
        var timeNow = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);

        bool isDarkMode = settings.DarkModeFrom < settings.DarkModeTo
            ? timeNow >= settings.DarkModeFrom && timeNow < settings.DarkModeTo
            : timeNow >= settings.DarkModeFrom || timeNow < settings.DarkModeTo;
        

        if (isDarkMode)
        {
            _brightness.SetBrightness((uint)settings.BrightnessDark);
            _theme.SetTheme(SystemThemeOption.Dark);
            _blueLight.TurnOn((uint)settings.BlueLightValue);
        }
        else
        {
            _brightness.SetBrightness((uint)settings.BrightnessLight);
            _theme.SetTheme(SystemThemeOption.Light);
            _blueLight.TurnOff();           
        }
    }
}