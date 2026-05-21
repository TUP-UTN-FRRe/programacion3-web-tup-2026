using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUP.Mundial.Entidades;

[Table("Equipo")]
public class Equipo
{
    [Key]
    public int EquipoId { get; set; }

    public string Nombre { get; set; }
}
