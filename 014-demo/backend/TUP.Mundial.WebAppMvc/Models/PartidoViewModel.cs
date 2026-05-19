namespace TUP.Mundial.WebAppMvc.Models
{
    public class PartidoViewModel
    {
        public string Fase { get; set; }
        public string Equipo1 { get; set; }
        public string Equipo2 { get; set; }

        public string TituloCompleto
        {
            get { 
                return $"Partido: {Equipo1} vs {Equipo2} - Fase: {Fase}";
            }
        }
    }
}
