using Circadia.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Circadia;

static class Program
{
    private static TimeBackgroundWorker? _worker;
    private static CancellationTokenSource? _cts;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();

        services.AddSingleton<IBlueLight, BlueLight>();
        services.AddSingleton<IBrightness, Brightness>();
        services.AddSingleton<ISystemTheme, SystemTheme>();
        services.AddSingleton<ISunTime, SunTime>();
        services.AddSingleton<ILocation, IpApiLocation>();

        services.AddSingleton<TimeBackgroundWorker>();
        services.AddSingleton<CircadiaApplicationContext>();

        using var serviceProvider = services.BuildServiceProvider();

        using var cts = new CancellationTokenSource();

        var worker = serviceProvider.GetRequiredService<TimeBackgroundWorker>();
        var applicationContext =
            serviceProvider.GetRequiredService<CircadiaApplicationContext>();

        _ = worker.StartAsync(cts.Token);

        Application.Run(applicationContext);

        cts.Cancel();
        worker.StopAsync(CancellationToken.None)
            .GetAwaiter()
            .GetResult();
    }
}