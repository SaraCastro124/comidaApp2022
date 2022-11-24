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
        Pedido pedido =
            new Pedido(idRestaurante: 2, idPedido: 2, NroPedido: 2, DateTime.Now, idCliente: 2, precio: 550, opinion: 10, descripcion: "sin condimentos");
        Ado.AltaPedido(pedido);
        Assert.Equal(1, pedido.IdPedido);
    }

    [Fact]
    public void TraerPedido()
    {
        var pedidos = Ado.ObtenerPedido();
        Assert.Contains(pedidos, p => p.IdPedido == 1 && p.Descripcion == "leche descremada");
    }
}

