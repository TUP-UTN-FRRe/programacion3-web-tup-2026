using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TUP.Mundial.Entidades.Interfaces;

namespace TUP.Mundial.Entidades;

[Table("Equipo")]
public class Equipo: IConNombre
{
    private List<Jugador> _plantel;

    public Equipo()
    {
        _plantel = new List<Jugador>();
    }


    [Key]
    public int EquipoId { get; set; }

    public string Nombre { get; set; }


    public void Agregar(Jugador jugador) { 
        _plantel.Add(jugador);
    }


}
