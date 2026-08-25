using System.Text.Json;

namespace Circadia.Features;

public class SunTime : ISunTime
{
    public async Task<SunTiming> GetSunTiming(float lat, float lon)
    {
        using var client = new HttpClient();

        var date = DateTime.Now;

        string url =
            $"https://api.sunrise-sunset.org/json" +
            $"?lat={lat}&lng={lon}" +
            $"&date={date:yyyy-MM-dd}&formatted=0";

        string json = await client.GetStringAsync(url);

        using JsonDocument doc = JsonDocument.Parse(json);

        if (doc.RootElement.GetProperty("status").GetString() != "OK")
            return null;

        var results = doc.RootElement.GetProperty("results");

        return new SunTiming()
        {
            Sunrise = DateTime.Parse(results.GetProperty("sunrise").GetString()!).ToLocalTime(),
            Sunset = DateTime.Parse(results.GetProperty("sunset").GetString()!).ToLocalTime()
        };
    }
}