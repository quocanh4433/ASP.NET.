
using MiddlewareExtention.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();


// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.WriteAsync(" - From middleware 1 - ");
    await next(context);
});


// Middleware 2
/*app.UseMiddleware<MyCustomMiddleware>();*/
app.UseMyCustomMiddleware();

// Middleware 3
app.Run(async (HttpContext context) =>
{
    context.Response.WriteAsync(" - From middleware 3 - ");
});

app.Run();
