namespace comidApp.Core
{
    public class Plato
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ushort Id { get; set; }
        public double PrecioUnitario { get; set; }
        public ushort IdRestaurante { get; set; } 
        public ushort Disponibilidad { get; set; }

    }
}