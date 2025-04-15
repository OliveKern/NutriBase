
using System.ComponentModel;
using NutriBase.Logic.Contracts;
using NutriBase.Logic.Services;
using NutriBase.WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// builder.Services.Add()
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configuration of Http request pipeline
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
                .WithOrigins("http://localhost:4200", "https://localhost:4200", "http://localhost:8100", "https://localhost:8100"));

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
