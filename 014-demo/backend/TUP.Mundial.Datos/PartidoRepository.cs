using TUP.Mundial.Entidades;

namespace TUP.Mundial.Datos
{
    public class PartidoRepository
    {
        public PartidoRepository() { }

        public List<Partido> ObtenerListado()
        {
            var partidos = new List<Partido>();
 
            for (int i = 1; i < 100; i++)
            {                
                partidos.Add(new Partido()
                {
                    Local = new Equipo() { Nombre = $"Equipo Local {i}" },
                    Visitante = new Equipo() { Nombre = $"Equipo Visitante {i}" }
                });

            }

            return partidos;
        }
    }
}
