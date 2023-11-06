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

    // Contraint: ràng buộc về kiểu dữ liệu datetime, boolean, int. guid, minLenght(value), maxLength(value), length(min,max)
    endpoints.Map("devices/details/{deviceId:int:min(20):max(40)}", async (context) =>
    {
        int deviceId = Convert.ToInt32(context.Request.RouteValues["deviceId"]);
        await context.Response.WriteAsync($"Device ID: {deviceId}");
    });

    endpoints.Map("daily-digest-report/{reportDate:datetime}", async (context) =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportDate"]);
        await context.Response.WriteAsync($"In daily disget report: {reportDate}");
    });

    endpoints.Map("cities/{cityGuid:guid}", async (context) =>
    {
        Guid cityGuid = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityGuid"]));
        await context.Response.WriteAsync($"City Infomation: {cityGuid}");
    });

    endpoints.Map("cars/profile/{carName:minLength(4):maxLength(10)=audi}", async (context) =>
    {
        string carName = Convert.ToString(context.Request.RouteValues["carName"]);
        await context.Response.WriteAsync($"Car name: {carName}");
    });


    endpoints.Map("sale-reports/year:int::min(1900)/{month:regex(^(apr|jul|jan)$)}}", async (context) =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Sale report date: {year} - {month}");
    });

});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"No route match at {context.Request.Path}");
});

app.Run();
