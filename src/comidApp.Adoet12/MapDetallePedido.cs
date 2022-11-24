
using System.Data;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;

public class MapDetallePedido : Mapeador<DetallePedido>
{
    public MapDetallePedido(AdoAGBD ado) : base(ado)
        => Tabla = "detallePedido";

    public override DetallePedido ObjetoDesdeFila(DataRow fila)
        => new DetallePedido(
        idPlato: Convert.ToUInt16(fila["idPlato"]),
        NroPedido: Convert.ToUInt16(fila["NroPedido"]),
        cantidad: Convert.ToByte(fila["cantidad"]),
        precio: Convert.ToDouble(fila["precio"])
    );

    public void AltaDetallePedido(DetallePedido DetallePedido)
    {
        EjecutarComandoCon("AltadetallePedido", ConfigurarAltaDetallePedido, DetallePedido);
    }

    private void ConfigurarAltaDetallePedido(DetallePedido DetallePedido)
    {
        SetComandoSP("AltadetallePedido");

        BP.CrearParametro("unIdPlato")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(DetallePedido.IdPlato)
        .AgregarParametro();

        BP.CrearParametro("unNroPedido")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(DetallePedido.NroPedido)
        .AgregarParametro();

        BP.CrearParametro("unaCantidad")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(DetallePedido.Cantidad)
        .AgregarParametro();

        BP.CrearParametro("unPrecio")
        .SetTipoDecimal(7, 2)
        .SetValor(DetallePedido.Precio)
        .AgregarParametro();
    }
}
