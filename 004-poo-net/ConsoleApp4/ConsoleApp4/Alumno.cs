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

    public int Edad { get { return 22; } }

    public DateTime FechaNacimiento { get; set; }



    //public void SetNombre(string nombre)
    //{
    //    _nombre = nombre;
    //}


}