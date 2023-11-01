using _02._CustomMiddleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.Services.AddTransient<MyCustomMiddleware>();


// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.WriteAsync(" - From middleware 1 - ");
    await next(context);
});


// Middleware 2
app.UseMiddleware<MyCustomMiddleware>();

// Middleware 3
app.Run(async (HttpContext context) =>
{
    context.Response.WriteAsync(" - From middleware 3 - ");
});

app.Run();
