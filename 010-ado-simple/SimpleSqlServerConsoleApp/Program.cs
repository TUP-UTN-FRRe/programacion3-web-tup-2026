using Microsoft.Data.SqlClient;

Console.WriteLine("ADO Simple!");

///www.conectionstring.com 
var connectionString = "Server=localhost;Database=StarwarsGalaxy;Integrated Security=True;TrustServerCertificate=True;";

//1 Conexion
var conn = new SqlConnection(connectionString);

//2 Comando
var QUERY_SQL = "SELECT JediId, Nombre FROM dbo.Jedi";

var cmd = new SqlCommand();
cmd.CommandText = QUERY_SQL;
cmd.Connection = conn;
cmd.CommandType = System.Data.CommandType.Text;


conn.Open();

var reader = cmd.ExecuteReader();

while (reader.Read()) 
{
    var nombre1 = reader.GetString(1);
    var nombre2 = reader["Nombre"].ToString();
    var nombre3 = reader.GetString(reader.GetOrdinal("Nombre"));

    Console.WriteLine($"Jedi: {nombre3}");
}


Console.WriteLine("OK: Connection established");
