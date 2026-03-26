public class Alumno
{
    private string _nombre;

    public Alumno()
    {
    }

    public string Nombre
    {
        get { 
            //accion
            return _nombre; 
        }
        set {
            //acccion 
            _nombre = value;
        }
    }

    public string Apellido { get; set; }


    //public int Edad { get; set; }

    public int Edad { get { return CalcularEdad(); } }

    public DateTime FechaNacimiento { get; set; }

    private int CalcularEdad()
    {
        var hoy = DateTime.Today;
        var edad = hoy.Year - FechaNacimiento.Year;

        if (FechaNacimiento.Date > hoy.AddYears(-edad))
        {
            edad--;
        }

        return edad;
    }



    //public void SetNombre(string nombre)
    //{
    //    _nombre = nombre;
    //}


}