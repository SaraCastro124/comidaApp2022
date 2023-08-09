
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class PlatoTest
{
    public AdoComidApp Ado { get; set; }
    public PlatoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoComidApp(adoAGBD);
    }

    [Fact]
    public void registrarPlato()
    {
        Plato plato = new Plato("Te Frio", "Te con hielo", idPlato: 4, precioUnitario: 234, idRestaurante: 1, disponibilidad: 120);
        Ado.AltaPlato(plato);
        Assert.Equal(4, plato.idPlato);
    }

    [Fact]
    public void TraerPlato()
    {
        var platos = Ado.ObtenerPlato();
        Assert.Contains(platos, p => p.Nombre == p.Nombre && p.Descripcion == "cafe con espuma y leche");
    }
}