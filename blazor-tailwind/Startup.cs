using BlazorTailwindTemplate.Data;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfigurationBuilder config)
    {
        services.AddSingleton<WeatherForecastService>();
    }
}