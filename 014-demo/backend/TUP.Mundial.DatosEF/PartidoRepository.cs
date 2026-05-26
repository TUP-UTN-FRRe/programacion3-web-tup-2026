using Microsoft.EntityFrameworkCore;
using TUP.Mundial.Entidades;

namespace TUP.Mundial.DatosEF
{
    public class PartidoRepository
    {
        
        public PartidoRepository() { }

        public List<Partido> ObtenerListado() {
            return ObtenerListadoDB();
        }

        private List<Partido> ObtenerListadoDB()
        {
            using (var context = new MundialFIFA2026Context())
            {
                //LINQ
                var query = context.Partidos
                                    .Include(p => p.Local)
                                    .Include(p => p.Visitante);


                //var query2 = from p in context.Partidos
                //             select p.Local;



                return query.ToList();
            }
        }

      
    }
}
