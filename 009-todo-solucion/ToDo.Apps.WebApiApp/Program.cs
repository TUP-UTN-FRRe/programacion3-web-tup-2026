var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/api/item", () =>
{
    //var items = new List<ToDo.Entidades.Item>();

    //for (int i = 1; i <= 10; i++)
    //{
    //    var item = new ToDo.Entidades.Item()
    //    {
    //        Titulo = $"Item {i}",
    //        Estado = (i % 2 == 0) // Marcar como completo si el número es par
    //    };
    //    //item.Titulo = $"Item {i}";
    //    //item.Estado = (i % 2 == 0); // Marcar como completo si el número es par

    //    items.Add(item);
    //}



    var itemNegocio = new ToDo.Negocio.ItemNegocio();
    var items = itemNegocio.ObtenerTodos();


    return items;
});

app.Run();

