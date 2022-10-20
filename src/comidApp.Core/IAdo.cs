using comidApp.Core;

namespace comidApp.Adoet12;

public interface IAdo
{
    void AltaCliente(Cliente cliente);
    List<Cliente> ObtenerCliente();

    /*void AltaRestaurante(Restaurante restaurante);
    List<Restaurante> ObtenerRestaurante();

    void AltaPlato(Plato plato);
    List<Plato> ObtenerPlato();

    void AltaPedido(Pedido pedido);
    List<Pedido> ObtenerPedido();

    void AltaVentaResto(VentaResto ventaResto);
    List<VentaResto> ObtenerVentaResto();

    void AltaDetallePedido(detallePedido detallePedido);
    List<detallePedido> ObtenerDetallePedido();*/

}