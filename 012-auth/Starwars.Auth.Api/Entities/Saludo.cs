using System.Text.Json.Serialization;

namespace Starwars.Auth.Api.Entities
{
    /// <summary>
    /// [JsonSerializable(typeof(Saludo))]
    /// </summary>
    public class Saludo
    {
        private readonly ISaludoModo _saludoModo;

        public Saludo(ISaludoModo saludoModo)
        {
            _saludoModo = saludoModo;
        }

        public string Saludar() { 
            return $"Hola, {DateTime.Now:HH:mm:ss} {_saludoModo.Accion()}";
        }

    }
}
