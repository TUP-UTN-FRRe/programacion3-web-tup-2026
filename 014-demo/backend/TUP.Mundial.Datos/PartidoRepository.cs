using Microsoft.Data.SqlClient;
using TUP.Mundial.Entidades;

namespace TUP.Mundial.Datos
{
    public class PartidoRepository
    {
        private const string QUERY_PARTIDOS = "SELECT \r\n\tP.PartidoId,\r\n\t[Local] = ELocal.Nombre,\r\n\tVisitante = EVis.Nombre\r\nFROM dbo.Partido P\r\n\tINNER JOIN dbo.Equipo ELocal \r\n\t\tON P.EquipoIdLocal = ELocal.EquipoId\r\n\tINNER JOIN dbo.Equipo EVis \r\n\t\tON P.EquipoIdVisitante = EVis.EquipoId\r\n";


        public PartidoRepository() { }

        public List<Partido> ObtenerListado() {
            return ObtenerListadoDB();
        }

        private List<Partido> ObtenerListadoDB()
        {
            List<Partido> partidos = new();


            ///www.conectionstring.com 
            var connectionString = "Server=localhost;Database=MundialFIFA2026;Integrated Security=True;TrustServerCertificate=True;";

            //1 Conexion 
            var conn = new SqlConnection(connectionString);

            //2 Comando
            var cmd = new SqlCommand();
            cmd.CommandText = QUERY_PARTIDOS;
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;


            //Ejecutar el comando 
            conn.Open();

            //Obtenemos un DataReader para leer los resultados de la consulta
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //var nombre1 = reader[1].ToString();
                //var nombre2 = reader.GetString(1);
                var partidoId = reader.GetInt32(reader.GetOrdinal("PartidoId"));
                var local = reader.GetString(reader.GetOrdinal("Local"));
                var visitante = reader.GetString(reader.GetOrdinal("Visitante"));

                var partido = new Partido
                {
                    PartidoId = partidoId,
                    Local = new Equipo { Nombre = local },
                    Visitante = new Equipo { Nombre = visitante }
                };

                partidos.Add(partido);
            }

            reader.Close();
            conn.Close();

            return partidos;

        }

        public List<Partido> ObtenerListadoArray()
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
