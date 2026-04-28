using Microsoft.Data.SqlClient;
using Starwars.Core.Entities;

namespace Starwars.Core.Data
{
    public class JediRepository
    {
        public List<Jedi> GetAll()
        {
            var jedis = new List<Jedi>();


            ///www.conectionstring.com 
            var connectionString = "Server=localhost;Database=StarwarsGalaxy;Integrated Security=True;TrustServerCertificate=True;";

            //1 Conexion 
            var conn = new SqlConnection(connectionString);

            //2 Comando
            var cmd = new SqlCommand();
            cmd.CommandText = "SELECT JediId, Nombre FROM dbo.Jedi";
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
                var nombre = reader.GetString(reader.GetOrdinal("Nombre"));

                var jedi = new Jedi
                {
                    JediId = reader.GetInt32(reader.GetOrdinal("JediId")),
                    Nombre = nombre
                };

                jedis.Add(jedi);
            }

            reader.Close();
            conn.Close();

            return jedis;

            }

        
    }
}
