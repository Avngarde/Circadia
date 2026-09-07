using System.Text.Json;

namespace Circadia.Features;

public class IpApiLocation : ILocation
{
    private static readonly HttpClient Client = new();

    public async Task<LocationInfo?> GetLocation()
    {
        string json = await Client.GetStringAsync(
            "http://ip-api.com/json/?fields=regionName,country,lat,lon");
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        return JsonSerializer.Deserialize<LocationInfo>(json, options);
    }
}