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


        [Fact]
        public void DebeCrearUnAlumnoDe22Anios()
        {

            var c1 = new Alumno();

            c1.FechaNacimiento = new DateTime(2004, 1, 1);
            //c1.Edad = 22;

            Assert.Equal(22, c1.Edad);
            Assert.Equal(2004, c1.FechaNacimiento.Year);

        }

        [Fact]
        public void DebeCrearUnAlumnoDe3Anios()
        {

            var c1 = new Alumno();

            c1.FechaNacimiento = new DateTime(2022, 12, 18);
          

            Assert.Equal(3, c1.Edad);
            Assert.Equal(2022, c1.FechaNacimiento.Year);

        }
    }
}
