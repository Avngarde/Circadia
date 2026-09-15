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
    private SystemThemeOption _currentTheme;
    private SettingsValues _settings;

    public TimeBackgroundWorker()
    {
        _theme = new SystemTheme();
        _brightness = new Brightness();
        _blueLight = new BlueLight();   

        _currentTheme = _theme.GetTheme(); 
        _settings = Settings.Load();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer (TimeSpan.FromSeconds(45));

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
        var timeNow = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);
        bool isDarkMode;

        if (_settings.DarkModeFrom > _settings.DarkModeTo) // Clocks moves past 00:00 during the dark mode span
            isDarkMode = timeNow > _settings.DarkModeFrom || timeNow < _settings.DarkModeTo;
        else
            isDarkMode = timeNow > _settings.DarkModeFrom && timeNow < _settings.DarkModeTo;

        if ((isDarkMode && _currentTheme == SystemThemeOption.Dark) 
            || 
           (!isDarkMode && _currentTheme == SystemThemeOption.Light))
            return;
    
        if (isDarkMode)
        {
            _brightness.SetBrightness((uint)_settings.BrightnessDark);
            _theme.SetTheme(SystemThemeOption.Dark);
            _blueLight.TurnOn((uint)_settings.BlueLightValue);

            _currentTheme = SystemThemeOption.Dark;
        }
        else
        {
            _brightness.SetBrightness((uint)_settings.BrightnessLight);
            _theme.SetTheme(SystemThemeOption.Light);
            _blueLight.TurnOff(); 

            _currentTheme = SystemThemeOption.Light;         
        }
    }
}