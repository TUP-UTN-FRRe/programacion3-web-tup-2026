namespace ToDo.Entidades.Tests
{
    public class ItemTest
    {
        [Fact]
        public void Test1()
        {
            var item = new Item();
            item.Titulo = "Comprar leche";
            item.Estado = false;

            Assert.Equal("Comprar leche", item.Titulo);
            Assert.False(item.Estado);
        }


        [Fact]
        public void ItemDebeTenerToStringCompleto()
        {
            var item = new Item();
            item.Titulo = "Comprar leche";
            item.Estado = false;

            Assert.Equal("Comprar leche", item.Titulo);
            Assert.False(item.Estado);
            Assert.Equal("Comprar leche (Pendiente)", item.ToString());

        }


        [Fact]
        public void ItemDebeTenerToStringCompleto2()
        {
            var item = new Item();
            item.Titulo = "Item de Ejemplo 2";
            item.Estado = true;

            Assert.Equal("Item de Ejemplo 2", item.Titulo);
            Assert.True(item.Estado);
            Assert.Equal("Item de Ejemplo 2 (Completo)", item.ToString());

        }

        [Fact]
        public void Titulo_AsignarYObtener_DebeRetornarValor()
        {
            var item = new Item { Titulo = "Comprar leche" };
            Assert.Equal("Comprar leche", item.Titulo);
        }

        [Fact]
        public void Color_AsignarYObtener_DebeRetornarValor()
        {
            var item = new Item { Color = "Rojo" };
            Assert.Equal("Rojo", item.Color);
        }

        [Fact]
        public void Estado_PorDefecto_DebeSerFalse()
        {
            var item = new Item();
            Assert.False(item.Estado);
        }

        [Fact]
        public void Estado_AsignarTrue_DebeRetornarTrue()
        {
            var item = new Item { Estado = true };
            Assert.True(item.Estado);
        }

        [Fact]
        public void ToString_EstadoPendiente_DebeRetornarFormatoCorrecto()
        {
            var item = new Item { Titulo = "Tarea", Estado = false };
            Assert.Equal("Tarea (Pendiente)", item.ToString());
        }

        [Fact]
        public void ToString_EstadoCompleto_DebeRetornarFormatoCorrecto()
        {
            var item = new Item { Titulo = "Tarea", Estado = true };
            Assert.Equal("Tarea (Completo)", item.ToString());
        }
    }
}
