namespace comidApp.Core;
public abstract class CosaPedido
{
    public List<Pedido> Pedidos { get; set; }

    public CosaPedido() => this.Pedidos = new List<Pedido>();
    public void AgregarPedido(Pedido pedido)
        => Pedidos.Add(pedido);
}
