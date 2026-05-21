
using TUP.Mundial.Entidades;

namespace TUP.Mundial.Negocio
{
    public class PartidoNegocio
    {

        public PartidoNegocio() { 
        
        }

        public List<Partido> ObtenerListado()
        {
            return ObtenerListadoEF();
        }

        public List<Partido> ObtenerListadoEF()
        {
            var partidoRepository = new TUP.Mundial.DatosEF.PartidoRepository();
            return partidoRepository.ObtenerListado();
        }

        public List<Partido> ObtenerListadoADONET()
        {
            var partidoRepository = new TUP.Mundial.Datos.PartidoRepository();
            return partidoRepository.ObtenerListado();
        }
    }
}
