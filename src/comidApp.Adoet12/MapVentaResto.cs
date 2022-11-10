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

        public void AltaVentaResto(VentaResto ventaResto)
        {
            EjecutarComandoCon("AltaVentaResto", ConfigurarAltaVentaResto, ventaResto);
        }
        private void ConfigurarAltaVentaResto(VentaResto ventaResto)
        {
            SetComandoSP("AltaVentaResto");

            BP.CrearParametro("unAnio")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(ventaResto.Anio)
            .AgregarParametro();

            BP.CrearParametro("unIdPlato")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(ventaResto.IdPlato)
            .AgregarParametro();

            BP.CrearParametro("unMes")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
            .SetValor(ventaResto.Mes)
            .AgregarParametro();

            BP.CrearParametro("idRestaurante")
            .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
            .SetValor(ventaResto.IdRestaurante)
            .AgregarParametro();

            BP.CrearParametro("unMonto")
            .SetTipoDecimal(9, 2)
            .SetValor(ventaResto.Monto)
            .AgregarParametro();

        }

    }
}