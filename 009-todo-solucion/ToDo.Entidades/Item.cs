namespace ToDo.Entidades
{
    public class Item
    {
        public string Titulo { get; set; }


        private bool _estado;

        public bool Estado
        {
            get {
                //acciones antes de retornar el valor
                return _estado; 
            }
            set {
                //acciones antes de asignar el valor
                _estado = value;
            }
        }

        public override string ToString()
        {
            //return "Comprar leche (Pendiente)";
            //return Titulo + " (" + (Estado ? "Completo" : "Pendiente") + ")";
            return $"{Titulo} ({(Estado ? "Completo" : "Pendiente")})";
        }

        public string Color { get; set; }

    }
}
