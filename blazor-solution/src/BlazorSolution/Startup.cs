using BlazorSolution.Core.Services;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfigurationBuilder config)
    {
        services.AddSingleton<WeatherForecastService>();
    }
}