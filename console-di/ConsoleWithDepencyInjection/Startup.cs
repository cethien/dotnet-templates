using ConsoleWithDepencyInjection.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
    {

    }

    public static void AddHelloWorld(this IServiceCollection services)
    {
        services.AddSingleton<IHelloWorldService, HelloWorldService>();
    }

    public static void UseHelloWorld(this IHost host)
    {
        var svc = host.Services.GetRequiredService<IHelloWorldService>();
        svc.PrintHelloWorld();        
    }
}
