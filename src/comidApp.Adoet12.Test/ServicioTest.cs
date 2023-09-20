using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class ServicioTest
{
    private readonly Servicio _servicio;
    public ServicioTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoComidApp(adoAGBD);
        _servicio = new Servicio(Ado);
    }

    [Fact]
    public void AltaCliente()
    {
        Cliente cliente = new Cliente()
        {
            //TODO darle valores
        }
        var execp = Assert.Throws<InvalidOperationException>(()=> )
    }
}
