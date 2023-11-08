var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // adds all the controller classes as services
var app = builder.Build();

// Cachs 1
/*app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});*/


// Cach 2: MapController automatically call UseRouting + UseEndpoints
app.MapControllers();

app.Run();
