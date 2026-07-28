using System.Text.Json;

namespace Circadia.Features;

public static class Settings
{
    public static void Save(SettingsValues settings)
    {
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions());

        File.WriteAllText("settings.json", json);
    }

    public static SettingsValues? Load()
    {
        var json = File.ReadAllText("settings.json");
        var model = JsonSerializer.Deserialize<SettingsValues>(json);

        return model;
    }

    public static bool SettingsFileExists() 
        => File.Exists("settings.json");

    public static void CreateDefault()
    {
        SettingsValues settings = new()
        {
            BrightnessDark = 40,
            BrightnessLight = 90,
            DarkModeFrom = TimeOnly.Parse("21:00"),
            DarkModeTo = TimeOnly.Parse("07:00"),
        };
        
        Save(settings);
    }
}