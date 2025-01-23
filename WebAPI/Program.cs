using System.Collections.ObjectModel;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


var temps = new Dictionary<string, int>(capacity: 5)
{
    { "cold", 8 },
    { "mild", 15 },
    { "warm", 20 },
};


app.MapGet("/weatherforecast/{weather}", (string weather) =>
{
    int temp = temps.GetOrAdd(weather, 32);
    return $"The temperature is {temp} Celsius.";
});

await app.RunAsync();

