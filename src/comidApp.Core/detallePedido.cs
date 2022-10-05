namespace comidApp.Core
{
    public class detallePedido
    {
        public ushort Id { get; set; }
        public ushort NroPedido { get; set; }
        public byte Cantidad { get; set; }
        public double Precio { get; set; }
        public detallePedido (ushort id, ushort NroPedido, byte cantidad, double precio)
        {
            this.Id = id;
            this.NroPedido = NroPedido;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }
    }
}