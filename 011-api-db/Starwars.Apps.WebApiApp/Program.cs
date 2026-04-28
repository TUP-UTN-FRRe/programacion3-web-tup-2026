using Starwars.Core.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAll");

app.UseHttpsRedirection();


app.MapGet("/api/jedi", () =>
{
    var jedis = (new JediBusiness()).GetAll();
    return jedis;
});

app.Run();

