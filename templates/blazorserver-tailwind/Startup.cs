using Blazored.LocalStorage;
using BlazorServerTailwindTemplate.Data;

public static class Startup{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration config){
        services.AddBlazoredLocalStorage();
        services.AddSingleton<WeatherForecastService>();
    }
}