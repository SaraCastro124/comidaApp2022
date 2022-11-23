
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
        var cantidadDetalles = Ado.MapDetalle.FilasFiltradas("idPedido", 7).Count;
        Ado.altaDetallePedido(detallePedido);
        var nuevaCantidad = Ado.MapDetalle.FilasFiltradas("idPedido", 7).Count;
        Assert.Equal(cantidadDetalles + 1, nuevaCantidad);
    }

    [Fact]
    public void TraerDetallePedido()
    {
        var detallePedidos = Ado.ObtenerDetallePedido();
        Assert.Contains(detallePedidos, dp => dp.IdPlato == 1 && dp.NroPedido == 3);
    }
}