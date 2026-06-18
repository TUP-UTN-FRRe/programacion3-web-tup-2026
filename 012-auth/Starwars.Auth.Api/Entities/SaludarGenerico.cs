namespace Starwars.Auth.Api.Entities
{
    //public class SaludarGenerico
    //{
    //    public string Saludar(IConNombre nombre) 
    //    { 
    //        return $"Hola {nombre.Nombre}!";
    //    }
    //}

    public class SaludarGenerico<T> where T : class
    {
        private T _objecto;

        //public SaludarGenerico(T objecto)
        //{
        //    List<T> list = new List<T>();
        //    _objecto = objecto;
        //}
        public string Saludar(T objecto)
        {
            return "HOla";
            //return $"Hola {objecto.Nombre}!";
        }
    }
}
