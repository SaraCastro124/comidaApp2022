namespace comidApp.Core;
public class Pedido
{
    public ushort IdPedido { get; set; }
    public ushort NroPedido { get; set; }
    public DateTime FechaHora { get; set; }
    public ushort IdCliente { get; set; }
    public double Precio { get; set; }
    public  byte Opinion { get; set; }
    public string Descripcion { get; set; }
    
    public Pedido (ushort idPedido, ushort NroPedido, DateTime fechaHora, ushort idCliente, double precio, byte opinion, string descripcion)
    {
        this.IdPedido = idPedido;
        this.NroPedido = NroPedido;
        this.FechaHora = fechaHora;
        this.IdCliente = idCliente;
        this.Precio = precio;
        this.Opinion= opinion;
        this.Descripcion = descripcion;
    }
}

