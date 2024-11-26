
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// builder.Services.Add()
var services = builder.Services;

services.AddControllers();
services.AddCors();

var app = builder.Build();

// Configuration of Http request pipeline
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http:://localhost:4200", "https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
