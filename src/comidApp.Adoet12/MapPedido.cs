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
            idPedido: Convert.ToByte(fila["NroPedido"]),
            idCliente : Convert.ToUInt16(fila["idCliente"]),
            NroPedido: Convert.ToByte(fila["NroPedido"]),
            fechaHora: Convert.ToDateTime(fila["fechaHora"]),
            precio: Convert.ToDouble(fila["precio"]),
            opinion: Convert.ToByte(fila["opinion"]),
            descripcion: fila["descrpcion"].ToString()!
        );
    
    public void AltaPedido(Pedido pedido)
    {
        EjecutarComandoCon("AltaPedido", ConfigurarAltaPedido, PostAltaPedido, pedido);
    }
    
    private void ConfigurarAltaPedido(Pedido pedido)
    {
        SetComandoSP("AltaPedido");

        BP.CrearParametroSalida("unIdPedido")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .AgregarParametro();

        BP.CrearParametro("unNroPedido")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(pedido.NroPedido)
        .AgregarParametro();

        BP.CrearParametro("unaFechaHora")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
        .SetValor(pedido.FechaHora)
        .AgregarParametro();

        BP.CrearParametro("idCliente")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(pedido.IdCliente)
        .AgregarParametro();

        BP.CrearParametro("precio")
        .SetTipoDecimal(7, 2)
        .SetValor(pedido.Precio)
        .AgregarParametro();

        BP.CrearParametro("opinion")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
        .SetValor(pedido.Opinion)
        .AgregarParametro();

        BP.CrearParametro("descripcion")
        .SetTipoVarchar(50)
        .SetValor(pedido.Descripcion)
        .AgregarParametro();
    }

    private void PostAltaPedido(Pedido pedido)
    => pedido.IdPedido = Convert.ToUInt16(GetParametro("unIdPedido").Value);
}
