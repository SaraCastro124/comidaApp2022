
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
        DetallePedido detallePedido = new DetallePedido(5, 7, 1, 500);
        Ado.AltaDetallePedido(detallePedido);
        Assert.Equal(3, detallePedido.);
    }

    [Fact]

    public void TraerDetallePedido()
    {
        var detallePedidos = Ado.ObtenerDetallePedido();
        Assert.Contains(detallePedidos, dp => dp.)
    }
}