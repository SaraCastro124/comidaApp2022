using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12;

public class AdoComidApp : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapCliente MapCliente { get; set; }
    public MapPedido MapPedido { get; set; }
    public MapRestaurante MapRestaurante { get; set; }
    public MapPlato MapPlato { get; set; }
    public MapDetallePedido MapDetalle { get; set; }
    public AdoComidApp(AdoAGBD ado)
    {
        Ado = ado;
        MapCliente = new MapCliente(Ado);
        MapPedido = new MapPedido(Ado);
        MapRestaurante = new MapRestaurante(Ado);
        MapPlato = new MapPlato(Ado);
        MapDetalle = new MapDetallePedido(Ado);
    }
    #region Cliente
    public void AltaCliente(Cliente cliente)
        => MapCliente.AltaCliente(cliente);

    public List<Cliente> ObtenerCliente()
        => MapCliente.ColeccionDesdeTabla();
    #endregion

    #region Pedido
    public void AltaPedido(Pedido pedido)
        => MapPedido.AltaPedido(pedido);
    public List<Pedido> ObtenerPedido()
        => MapPedido.ColeccionDesdeTabla();
    #endregion

    #region Restaurante
    public void AltaRestaurante(Restaurante restaurante)
        => MapRestaurante.AltaRestaurante(restaurante);
    public List<Restaurante> ObtenerRestaurante()
        => MapRestaurante.ColeccionDesdeTabla();
    #endregion

    #region Plato

    public void AltaPlato(Plato plato)
        => MapPlato.AltaPlato(plato);

    public List<Plato> ObtenerPLatos()
        => MapPlato.ColeccionDesdeTabla();
    #endregion

    #region DetallePedido
    public void altaDetallePedido(DetallePedido detallePedido)
        => MapDetalle.AltaDetallePedido(detallePedido);
    public List<DetallePedido> ObtenerDetallePedido()
        => MapDetalle.ColeccionDesdeTabla();
    #endregion

}