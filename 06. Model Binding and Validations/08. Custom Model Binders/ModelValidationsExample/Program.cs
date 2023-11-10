var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();   


app.Run();
