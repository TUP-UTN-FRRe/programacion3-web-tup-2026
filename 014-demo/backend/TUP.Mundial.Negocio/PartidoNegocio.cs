using TUP.Mundial.Datos;
using TUP.Mundial.Entidades;

namespace TUP.Mundial.Negocio
{
    public class PartidoNegocio
    {

        public PartidoNegocio() { 
        
        }

        public List<Partido> ObtenerListado()
        {
            var partidoRepository = new PartidoRepository();
            return partidoRepository.ObtenerListado();
        }
    }
}
