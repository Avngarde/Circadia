namespace Circadia.Features;

public interface ILocation
{
    public Task<LocationInfo?> GetLocation();
}

public class LocationInfo
{
    public string? RegionName { get; set; }
    public string? Country { get; set; }
    public float? Lat { get; set; }
    public float? Lon { get; set; }
}