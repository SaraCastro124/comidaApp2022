
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class DetallePedidoTest
{
    public AdoComidApp Ado { get; set; }
    public DetallePedidoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoComidApp(adoAGBD);
    }

    [Fact]
    public void registrarDetallePedido()
    {
        detallePedido DetallePedido = new detallePedido()
        Ado.AltaDetallePedido(DetallePedido);
        Assert.Equal
    }
}