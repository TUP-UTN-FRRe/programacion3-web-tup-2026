using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUP.Mundial.Entidades;

[Table("Partido")]
public class Partido
{
    //[Column("PartidoId")]
    [Key]
    public int PartidoId { get; set; }
    public DateTime Fecha { get; set; }
    public string Ciudad { get; set; }
    public string Estadio { get; set; }

    [ForeignKey("EquipoIdLocal")]
    public Equipo Local { get; set;}

    [ForeignKey("EquipoIdVisitante")]
    public Equipo Visitante { get; set; }
   
}
