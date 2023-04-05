using BlazorServerTailwindTemplate.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

public static class StartUp
{
    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddDbContextFactory<BlazorServerTailwindTemplateDbContext>(o =>
        o.UseSqlite("DataSource=BlazorServerTailwindTemplate.db"));

        return builder;
    }

    public static WebApplication Configure(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        return app;
    }

    public static async Task<WebApplication> ExecuteBeforeRunAsync(this WebApplication app)
    {
        var ctxFactory = app.Services.GetRequiredService<IDbContextFactory<BlazorServerTailwindTemplateDbContext>>();

        var ctx = await ctxFactory.CreateDbContextAsync();

        await ctx.Database.EnsureCreatedAsync();
        await ctx.Database.MigrateAsync();

        return app;
    }
}