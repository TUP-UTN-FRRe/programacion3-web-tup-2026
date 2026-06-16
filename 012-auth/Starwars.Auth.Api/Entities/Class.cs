namespace Starwars.Auth.Api.Entities
{
    public class Saludo
    {
        public string Saludar() { 
            return $"Hola, soy un saludo desde la clase Saludo a las {DateTime.Now:HH:mm:ss}";
        }

    }
}
