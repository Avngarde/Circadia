namespace Circadia.Features;

public interface ISunTime
{
    public Task<SunTiming> GetSunTiming(float lat, float lon);
}

public class SunTiming
{
    public DateTime Sunrise { get; set; }
    public DateTime Sunset { get; set; }
}