namespace comidApp.Core
{
    public class DetallePedido
    {
        public ushort IdPlato { get; set; }
        public ushort NroPedido { get; set; }
        public byte Cantidad { get; set; }
        public double Precio { get; set; }
        public DetallePedido (ushort idPlato, ushort NroPedido, byte cantidad, double precio)
        {
            this.IdPlato = idPlato;
            this.NroPedido = NroPedido;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }
    }
}