using ConfigurationExample.Services;

var builder = WebApplication.CreateBuilder(args);
// Service
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<FinnhubService>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();


app.Run();

