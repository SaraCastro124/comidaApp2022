namespace comidApp.Core
{
    public class detallePedido
    {
        public ushort Id { get; set; }
        public ushort NroPedido { get; set; }
        public byte Cantidad { get; set; }
        public double Precio { get; set; }
    }
}