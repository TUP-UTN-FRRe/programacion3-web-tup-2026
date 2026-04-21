Console.WriteLine("TODO!");






//for (int i = 1; i <= 10; i++) {
//    var item = new ToDo.Entidades.Item()
//    {
//        Titulo = $"Item {i}",
//        Estado = (i % 2 == 0) // Marcar como completo si el número es par
//    };
//    //item.Titulo = $"Item {i}";
//    //item.Estado = (i % 2 == 0); // Marcar como completo si el número es par

//    Console.WriteLine($"Título: {item.Titulo}, Estado: {(item.Estado ? "Completo" : "Pendiente")}");
//}   




var itemNegocio = new ToDo.Negocio.ItemNegocio();
var items = itemNegocio.ObtenerTodos();

foreach (var item in items)
{
    Console.WriteLine($"Título: {item.Titulo}, Estado: {(item.Estado ? "Completo" : "Pendiente")}");
}
