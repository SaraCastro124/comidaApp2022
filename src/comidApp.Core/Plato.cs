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
        public Plato (string nombre, string descripcion, ushort id, double precioUnitario, ushort idRestaurante, ushort disponibilidad)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Id = id;
            this.PrecioUnitario = precioUnitario;
            this.IdRestaurante = idRestaurante;
            this.Disponibilidad = disponibilidad;
        }

    }
}