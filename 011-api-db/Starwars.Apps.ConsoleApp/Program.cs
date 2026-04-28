using Starwars.Core.Business;

Console.WriteLine("Hello, World!");


var jediBusiness = new JediBusiness();
var jedis = jediBusiness.GetAll();

foreach (var item in jedis) { 
    Console.WriteLine($"Jedi: {item.Nombre}");
}