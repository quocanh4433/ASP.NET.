var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello");
    await next(context);
});

// Middleware 2
app.Use(async (context, next) => {
    await context.Response.WriteAsync("Hello 02");
    await next(context);
});


// Middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello 03");
});

app.Run();
