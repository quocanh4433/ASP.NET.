using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions ()
{
    WebRootPath = "myroot" // Default is wwwroot
});
var app = builder.Build();

app.UseStaticFiles(); // Work with the web root path (myroot)
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
       Path.Combine(builder.Environment.ContentRootPath + "mywebroot")
   )
}); // Work with mywebroot


app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello"); 
    });
});

app.Run();
