using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class RestauranteTest
{
    public AdoComidApp Ado{get; set;}
    public RestauranteTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoComidApp(adoAGBD);
    }

    [Fact]
    public void registrarRestaurante()
    {
        Restaurante restaurante = new Restaurante(20, "ohTea@gmail.com", "OhTea", "Abasto Shopping", "mine_.123");
        Ado.AltaRestaurante(restaurante);
        Assert.Equal(3, restaurante.idRestaurante);
    }

    [Fact]
    public void TraerRestaurante()
    {
        var restaurantes = Ado.ObtenerRestaurante();
        Assert.Contains(restaurantes, r => r.idRestaurante == 2 && r.Nombre == "Tucson");
    }
}