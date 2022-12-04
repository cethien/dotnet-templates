using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();
builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddHelloWorld();

var app = builder.Build();

app.UseHelloWorld();