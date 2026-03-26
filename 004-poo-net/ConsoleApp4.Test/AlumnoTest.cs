namespace ConsoleApp4.Test
{
    public class AlumnoTest
    {
        [Fact]
        public void TestSimple1()
        {
            var x = 1;
            var y = 2;
            var resultado = x + y;

            Assert.Equal(3, resultado);

        }


        [Fact]
        public void DebeCrearUnAlumnoConNombre()
        {

            var c1 = new Alumno();

            c1.Nombre = "Programacion III";

            Assert.Equal("Programacion III", c1.Nombre);

        }
    }
}
