
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

    public void AltaDetallePedido(DetallePedido detallePedido)
    {
        EjecutarComandoCon("AltadetallePedido", ConfigurarAltaDetallePedido, detallePedido);
    }

    public async Task AltaDetallePedidoAsync(DetallePedido detallePedido)
        => await EjecutarComandoAsync("AltadetallePedido", ConfigurarAltaDetallePedido, detallePedido);


    private void ConfigurarAltaDetallePedido(DetallePedido detallePedido)
    {
        SetComandoSP("AltadetallePedido");

        BP.CrearParametro("unIdPlato")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(detallePedido.IdPlato)
        .AgregarParametro();

        BP.CrearParametro("unNroPedido")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(detallePedido.NroPedido)
        .AgregarParametro();

        BP.CrearParametro("unaCantidad")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(detallePedido.Cantidad)
        .AgregarParametro();

        BP.CrearParametro("unPrecio")
        .SetTipoDecimal(7, 2)
        .SetValor(detallePedido.Precio)
        .AgregarParametro();
    }
}
