using System.Data;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;

public class MapPedido : Mapeador<Pedido>
{
    public MapPedido(AdoAGBD ado) : base(ado)
        => Tabla = "Pedido";

    public override Pedido ObjetoDesdeFila(DataRow fila)
        => new Pedido(
            idRestaurante: Convert.ToByte(fila["idRestaurante"]),
            idCliente: Convert.ToUInt16(fila["idCliente"]),
            NroPedido: Convert.ToByte(fila["NroPedido"]),
            fechaHora: Convert.ToDateTime(fila["fechaHora"]),
            precio: Convert.ToDouble(fila["precio"]),
            opinion: Convert.ToByte(fila["opinion"]),
            descripcion: fila["descripcion"].ToString()!
        );

    public void AltaPedido(Pedido pedido)
    {
        EjecutarComandoCon("AltaPedido", ConfigurarAltaPedido, PostAltaPedido, pedido);
    }

    public async Task AltaPedidoAsync(Pedido pedido)
        => await EjecutarComandoAsync("AltaPedido", ConfigurarAltaPedido, PostAltaPedido, pedido);

    private void ConfigurarAltaPedido(Pedido pedido)
    {
        SetComandoSP("AltaPedido");

        BP.CrearParametro("unidRestaurante")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(pedido.idRestaurante)
        .AgregarParametro();

        BP.CrearParametroSalida("unNroPedido")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .AgregarParametro();

        BP.CrearParametro("unaFechaHora")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
        .SetValor(pedido.FechaHora)
        .AgregarParametro();

        BP.CrearParametro("unIdCliente")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(pedido.IdCliente)
        .AgregarParametro();

        BP.CrearParametro("unPrecio")
        .SetTipoDecimal(7, 2)
        .SetValor(pedido.Precio)
        .AgregarParametro();

        BP.CrearParametro("unaOpinion")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(pedido.Opinion)
        .AgregarParametro();

        BP.CrearParametro("unaDescripcion")
        .SetTipoVarchar(50)
        .SetValor(pedido.Descripcion)
        .AgregarParametro();
    }

    private void PostAltaPedido(Pedido pedido)
    => pedido.NroPedido = Convert.ToUInt16(GetParametro("unNroPedido").Value);
}
