using Starwars.Core.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/api/jedi", () =>
{
    var jedis = (new JediBusiness()).GetAll();
    return jedis;
});

app.Run();

