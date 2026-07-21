namespace Circadia.Features;

public interface ISystemTheme
{
    public void SetTheme(SystemThemeOption theme);
}

public enum SystemThemeOption
{
    Light,
    Dark
}