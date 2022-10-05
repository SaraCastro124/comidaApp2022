namespace comidApp.Core
{
    public class VentaResto
    {
        public ushort Anio { get; set; }
        public ushort IdPlato { get; set; }
        public byte Mes { get; set; }
        public ushort IdRestaurante { get; set; }
        public double Monto { get; set; }
        public VentaResto (ushort anio, ushort idPlato, byte mes, ushort idRestaurante, double monto)
        {
            this.Anio = anio;
            this.IdPlato = idPlato;
            this.Mes = mes;
            this.IdRestaurante = idRestaurante;
            this.Monto = monto;
        }
    }
}