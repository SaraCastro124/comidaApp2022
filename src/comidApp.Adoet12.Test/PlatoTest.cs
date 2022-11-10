
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class PlatoTest
{
    public AdoComidApp Ado{get; set;}
    public PlatoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoComidApp(adoAGBD);
    }
    
    [Fact]
    public void registrarPlato()
    {
        Plato plato = new Plato("frappuccino", "cafe con espuma y leche", 342, 480,);
        Ado.AltaPlato(plato);
        Assert.Equal(2, plato.idPlato);
    }

    [Fact]
    public void TraerPlato()
    {
        var platos = Ado.ObtenerPLatos();
        Assert.Contains(platos, p => p.Nombre == p.Nombre && p.Descripcion == "cafe con espuma y leche");
    }
}