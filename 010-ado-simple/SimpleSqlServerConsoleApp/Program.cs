using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

///www.conectionstring.com 
var connectionString = "Server=localhost;Database=StarwarsGalaxy;Integrated Security=True;TrustServerCertificate=True;";

//1 Conexion 
var conn = new SqlConnection(connectionString);


conn.Open();

Console.WriteLine("OK: Connection established");
