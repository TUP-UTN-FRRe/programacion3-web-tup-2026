namespace TUP.Mundial.Entidades;

public class Partido
{
    //public int PartidoId { get; set; }
    public DateTime Fecha { get; set; }
    public Equipo Local { get; set;}
    public Equipo Visitante { get; set; }
}
