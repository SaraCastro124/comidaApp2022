namespace comidApp.MVC.ViewModels
{
    public class PlatoViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ushort idPlato { get; set; }
        public double PrecioUnitario { get; set; }
        public ushort IdRestaurante { get; set; }
        public ushort Disponibilidad { get; set; }
    }
}