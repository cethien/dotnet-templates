using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

public static class Startup{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration? config = null, IWebAssemblyHostEnvironment? hostEnvironment = null){
        services.AddBlazoredLocalStorage();
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(hostEnvironment!.BaseAddress) });
    }
}