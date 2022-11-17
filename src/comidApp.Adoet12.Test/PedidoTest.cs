using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class PedidoTest
{
    public AdoComidApp Ado { get; set; }
    public PedidoTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoComidApp(adoAGBD);
    }

    [Fact]
    public void registrarPedido()
    {
        var tucson = Ado.MapRestaurante.FiltrarPorPK("idRestaurante", 2);
        Pedido pedido = new Pedido(13, 1, 120, DateTime.Now, 1, 500, 2, "sin condimentos");
        Ado.AltaPedido(pedido);
        Assert.Equal(2, pedido.IdPedido);
    }

    [Fact]
    public void TraerPedido()
    {
        var pedidos = Ado.ObtenerPedido();
        Assert.Contains(pedidos, p => p.IdPedido == 1 && p.Descripcion == "leche descremada");
    }
}

