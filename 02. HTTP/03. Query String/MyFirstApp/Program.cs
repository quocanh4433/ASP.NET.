var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*app.MapGet("/", () => "Hello World!");*/

app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    if(context.Request.Method == "GET")
    {
        if(context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<h1>{id}</h1>");
        }
    }
});

app.Run();
