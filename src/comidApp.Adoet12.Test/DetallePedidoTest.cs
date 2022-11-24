
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
        ushort nroPedido = 1;
        DetallePedido detallePedido =
            new DetallePedido(idPlato: 3, NroPedido: nroPedido, cantidad: 1, precio: 500);

        // cantidad de detalles antes de dar de alta
        var cantidadDetalles = Ado.MapDetalle.FilasFiltradas("NroPedido", nroPedido).Count;

        Ado.altaDetallePedido(detallePedido);

        // cantidad post alta
        var nuevaCantidad = Ado.MapDetalle.FilasFiltradas("NroPedido", nroPedido).Count;

        Assert.Equal(cantidadDetalles + 1, nuevaCantidad);
    }

    [Fact]
    public void TraerDetallePedido()
    {
        var detallePedidos = Ado.ObtenerDetallePedido();
        Assert.Contains(detallePedidos, dp => dp.IdPlato == 2 && dp.NroPedido == 1);
    }
}