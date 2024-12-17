
using System.ComponentModel;
using NutriBase.WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// builder.Services.Add()
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configuration of Http request pipeline
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
                .WithOrigins("http:://localhost:4200", "https://localhost:4200"));

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
