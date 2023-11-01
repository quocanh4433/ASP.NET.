var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    context => context.Request.Query.ContainsKey("username"), 
    app => {
        app.Use(async (context, next) =>
        {
            string username = context.Request.Query["username"];
            await context.Response.WriteAsync($"Hell from Middleware bracnch, I am {username} \n");
            await next();
        });
    });

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hell from Middleware main chain");
});

app.Run();
