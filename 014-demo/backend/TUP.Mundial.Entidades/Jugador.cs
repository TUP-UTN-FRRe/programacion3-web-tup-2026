using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TUP.Mundial.Entidades.Interfaces;

namespace TUP.Mundial.Entidades;

[Table("Jugador")]
public class Jugador: IConNombre
{
    [Key]
    public int JugadorId { get; set; }

    public string Nombre { get; set; }
}
