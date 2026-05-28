
using TUP.Mundial.Entidades;
using TUP.Mundial.Entidades.Filtros;

namespace TUP.Mundial.Negocio
{
    public class PartidoNegocio
    {

        public PartidoNegocio() { 
        
        }

        public List<Partido> ObtenerListado()
        {
            //return ObtenerListadoADONET();
            return ObtenerListadoEF(new PartidoFiltro());
        }

        public List<Partido> ObtenerListado(PartidoFiltro filtro)
        {
            //return ObtenerListadoADONET();
            return ObtenerListadoEF(filtro);
        }

        public List<Partido> ObtenerListadoEF(PartidoFiltro filtro)
        {
            var partidoRepository = new TUP.Mundial.DatosEF.PartidoRepository();
            return partidoRepository.ObtenerListado(filtro);
        }

        public List<Partido> ObtenerListadoADONET()
        {
            var partidoRepository = new TUP.Mundial.Datos.PartidoRepository();
            return partidoRepository.ObtenerListado();
        }
    }
}
