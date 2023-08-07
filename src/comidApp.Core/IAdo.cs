using comidApp.Core;

namespace comidApp.Adoet12;

public interface IAdo
{
    void AltaCliente(Cliente cliente);
    Task AltaClienteAsync(Cliente cliente);
    List<Cliente> ObtenerCliente();
    Task<List<Cliente>> ObtenerClienteAsync();
    
    void AltaRestaurante(Restaurante restaurante);
    Task AltaRestauranteAsync(Restaurante restaurante);
    List<Restaurante> ObtenerRestaurante();
    Task<List<Restaurante>> ObtenerRestauranteAsync();

    void AltaPlato(Plato plato);
    Task AltaPlatoAsync(Plato plato);
    List<Plato> ObtenerPlato();
    Task<List<Plato>> ObtenerPlatoAsync();

    void AltaPedido(Pedido pedido);
    Task AltaPedidoAsync(Pedido pedido);
    List<Pedido> ObtenerPedido();
    Task<List<Pedido>> ObtenerPedidoAsync();

    void AltaVentaResto(VentaResto ventaResto);
    Task AltaVentaRestoAsync(VentaResto ventaResto);
    List<VentaResto> ObtenerVentaResto();
    Task<List<VentaResto>> ObtenerVentaRestoAsync();

    void AltaDetallePedido(DetallePedido detallePedido);
    Task AltaDetallePedidoAsync(DetallePedido detallePedido);
    List<DetallePedido> ObtenerDetallePedido();
    Task<List<DetallePedido>> ObtenerDetallePedidoAsync();

}