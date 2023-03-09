using PackagesServer.StartupExtention;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bingo API V1");
    c.RoutePrefix = string.Empty;
});
app.UseRouting();
app.MapControllers();
app.Run();
