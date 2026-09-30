using System.Text.Json;

namespace Circadia.Features;

public static class Settings
{
    private static string _path = Path.Combine(Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData), "Circadia/settings.json");

    public static void Save(SettingsValues settings)
    {
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions());

        File.WriteAllText(_path, json);
    }

    public static SettingsValues? Load()
    {
        var json = File.ReadAllText(_path);
        var model = JsonSerializer.Deserialize<SettingsValues>(json);

        return model;
    }

    public static bool SettingsFileExists() 
        => File.Exists(_path);

    public static void CreateDefault()
    {
        SettingsValues settings = new()
        {
            BrightnessDark = 40,
            BrightnessLight = 90,
            DarkModeFrom = TimeOnly.Parse("21:00"),
            DarkModeTo = TimeOnly.Parse("07:00"),
            FirstLaunch = true
        };
        
        Directory.CreateDirectory(
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Circadia"
            )
        );

        Save(settings);
    }
}