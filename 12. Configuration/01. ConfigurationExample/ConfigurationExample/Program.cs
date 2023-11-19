using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoint =>
{
    endpoint.Map("/", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["MyKEY"] + "\n");
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("yy") + "\n");
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("yy", "ASP.NET CORE") + "\n");
        await context.Response.WriteAsync(Convert.ToString(app.Configuration.GetValue<int>("www", 112)));
    });
});
app.MapControllers();


app.Run();

