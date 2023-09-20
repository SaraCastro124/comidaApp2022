using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class ServicioTest
{
    public AdoComidApp Ado{get; set;}
    public ServicioTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoComidApp(adoAGBD);
    }

    [Fact]
    public void AltaCliente()
    {
        Cliente cliente = new Cliente("Barcenas", "Lucia", "tugatito@gmail.com")
        ado.AltaCliente(cliente);
    }
}
