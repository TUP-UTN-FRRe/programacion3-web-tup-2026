using ToDo.Entidades;

namespace ToDo.Datos
{
    public class ItemRepository
    {
        public List<Item> ObtenerTodos()
        {
            //Ir a la DB
            return new List<Item>
            {
                new Item { Titulo = "Comprar leche", Estado = false, Color = "Rojo" },
                new Item { Titulo = "Llamar a mamá", Estado = true, Color = "Verde" },
                new Item { Titulo = "Pagar facturas", Estado = false, Color = "Azul" },
                new Item { Titulo = "Hacer ejercicio", Estado = true, Color = "Amarillo" }
            };
        }

    }
}
