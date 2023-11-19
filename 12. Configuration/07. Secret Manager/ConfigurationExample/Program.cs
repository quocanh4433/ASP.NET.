using ConfigurationExample;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Supply an object of WeatherOption (with 'WeatherApi' section) as a service

builder.Services.Configure<WeatherOption>(builder.Configuration.GetSection("WeatherApi"));
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();


app.Run();

