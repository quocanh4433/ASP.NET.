var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Enable routing
app.UseRouting();

// Creating endpoint
app.UseEndpoints(endpoints =>
{
    endpoints.Map("file/{filename}.{extension}", async (context) =>
    {
        // Convert.ToString() handles null, while ToString() doesn't.
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = context.Request.RouteValues["extension"].ToString();

        await context.Response.WriteAsync($"In files: {fileName} - {extension}");
    });

    endpoints.Map("employee/profile/{EmployeeName=Anh}", async (context) =>
    {
        // lower or upper is doesnt matter
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);

        await context.Response.WriteAsync($"Emplyoee: {employeeName}");
    });

    endpoints.Map("products/details/{id=001}", async (context) =>
    {
      /*  int id = Convert.ToInt32(context.Request.RouteValues["id"]);*/
        string id = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"ID: {id}");
    });


    endpoints.Map("devices/details/{deviceId:int}", async (context) =>
    {
        int deviceId = Convert.ToInt32(context.Request.RouteValues["deviceId"]);
        await context.Response.WriteAsync($"ID: {deviceId}");
    });

    endpoints.Map("news/details/{postID?}", async (context) =>
    {
        if(context.Request.Query.ContainsKey("id"))
        {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"ID: {id}");

        } 
        else
        {
            await context.Response.WriteAsync("New is not supplied");
        }
    });

});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request recieved at {context.Request.Path}");
});

app.Run();
