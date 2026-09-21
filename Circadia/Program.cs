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

        _cts = new CancellationTokenSource();
        _worker = new TimeBackgroundWorker();
        _ = _worker.StartAsync(_cts.Token);

        Application.Run(new CircadiaApplicationContext());

        _cts.Cancel();
        _worker.StopAsync(CancellationToken.None).GetAwaiter().GetResult();
        _cts.Dispose();
    }
}