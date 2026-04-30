namespace ToDo.Entidades
{
    /// <summary>
    /// 
    /// </summary>
    public class Item
    {
        public string Titulo { get; set; }


        private bool _estado;

        /// <summary>
        /// Indica si el item esta terminado o no
        /// (false no terminado y true es terminado)
        /// </summary>
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
