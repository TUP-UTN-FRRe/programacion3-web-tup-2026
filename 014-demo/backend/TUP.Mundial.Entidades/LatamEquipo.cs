using System;
using System.Collections.Generic;
using System.Text;

namespace TUP.Mundial.Entidades.Interfaces
{
    public class LatamEquipo: Equipo
    {
        public void Demo() 
        { 
            this.Nombre = "Latam Equipo";
            this.Agregar(new Jugador() { Nombre = "Jugador 1" });
            
        }
    }
}
