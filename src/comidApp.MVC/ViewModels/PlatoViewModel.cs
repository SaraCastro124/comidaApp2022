using comidApp.Core;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace comidApp.MVC.ViewModels
{
    public class PlatoViewModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public ushort idPlato { get; set; }
        public double PrecioUnitario { get; set; }
        public ushort IdRestaurante { get; set; }
        public ushort Disponibilidad { get; set; }
        public SelectList? Restaurantes { get; set; }

        public PlatoViewModel(IEnumerable<Restaurante> restaurantes)
        {
            Restaurantes = new (restaurantes, 
                                dataTextField: nameof(Restaurante.Nombre),
                                dataValueField: nameof(Restaurante.idRestaurante));
        }
    }
}