using ModelValidationsExample.CustomModelBinder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(
    options => {
        //options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});
//builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();   


app.Run();
