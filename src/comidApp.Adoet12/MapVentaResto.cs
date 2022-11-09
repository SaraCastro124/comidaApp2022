using System.Data;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12
{
    public class MapVentaResto : Mapeador<VentaResto>
    {
        public MapVentaResto(AdoAGBD ado) : base(ado)
            => Tabla = "VentaResto";

        public override VentaResto ObjetoDesdeFila(DataRow fila)
            => new VentaResto(
                anio: Convert.ToUInt16(fila["anio"]),
                idPlato: Convert.ToUInt16(fila["idPlato"]),
                mes: Convert.ToByte(fila["mes"]),
                idRestaurante: Convert.ToUInt16(fila["idRestaurante"]),
                monto: Convert.ToDouble(fila["monto"])
            );
    }
}