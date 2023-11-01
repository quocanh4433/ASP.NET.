namespace _02._CustomMiddleware.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware - Start");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware - End");
        }
    }
}
