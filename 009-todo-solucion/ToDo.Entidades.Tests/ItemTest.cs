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
    }
}
