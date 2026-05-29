using Microsoft.EntityFrameworkCore;
using TUP.Mundial.Entidades;
using TUP.Mundial.Entidades.Filtros;

namespace TUP.Mundial.DatosEF
{
    public class PartidoRepository
    {
        
        public PartidoRepository() { }

        public List<Partido> ObtenerListado() {
            return ObtenerListadoDB(new PartidoFiltro());
        }


        public List<Partido> ObtenerListado(PartidoFiltro filtro)
        {
            return ObtenerListadoDB(filtro);
        }


        private List<Partido> ObtenerListadoDB(PartidoFiltro filtro)
        {
            using (var context = new MundialFIFA2026Context())
            {
                //LINQ
                var query = context.Partidos
                                    .Where(p => p.Local.Nombre.Contains(filtro.TextoABuscar) 
                                            || p.Visitante.Nombre.Contains(filtro.TextoABuscar))
                                    .Include(p => p.Local)
                                    .Include(p => p.Visitante);


                var query2 = from p in context.Partidos
                             where 
                                p.Local.Nombre.Contains(filtro.TextoABuscar)
                                || p.Visitante.Nombre.Contains(filtro.TextoABuscar)
                                || p.Ciudad.Contains(filtro.TextoABuscar)
                                || p.Estadio.Contains(filtro.TextoABuscar)
                             select p.Local;



                return query.ToList();
            }
        }


        public int Cantidad(PartidoFiltro filtro)
        {
            using (var context = new MundialFIFA2026Context())
            {
                //LINQ
                var query = context.Partidos
                                    .Where(p => p.Local.Nombre.Contains(filtro.TextoABuscar)
                                            || p.Visitante.Nombre.Contains(filtro.TextoABuscar))
                                    .Include(p => p.Local)
                                    .Include(p => p.Visitante);


                return query.Count();
            }
        }




    }
}
