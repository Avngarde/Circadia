namespace Circadia.Features;

public interface ISystemTheme
{
    public void SetTheme(SystemThemeOption theme);
    public SystemThemeOption GetTheme();
}

public enum SystemThemeOption
{
    Light,
    Dark
}