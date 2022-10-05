namespace comidApp.Core;
public class Pedido
{
    public ushort Id { get; set; }
    public ushort NroPedido { get; set; }
    public DateTime FechaHora { get; set; }
    public ushort IdCliente { get; set; }
    public double Precio { get; set; }
    public  byte Opinion { get; set; }
    public string Descripcion { get; set; }
}

