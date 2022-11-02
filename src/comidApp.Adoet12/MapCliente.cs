using System.Data;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;
public class MapCliente : Mapeador<Cliente>
{
    public MapCliente(AdoAGBD ado) : base(ado)
        => Tabla = "Cliente";
    public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente(
                IdCliente: Convert.ToByte(fila["idCliente"]),
                nombre: fila["nombre"].ToString()!,
                apellido: fila["apellido"].ToString()!,
                email: fila["email"].ToString()!,
                clave: fila["clave"].ToString()!
            );
            
    public void AltaCliente(Cliente cliente)
    {
        EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);
    }

    private void ConfigurarAltaCliente(Cliente cliente)
    {
        SetComandoSP("registrarCliente");

        BP.CrearParametroSalida("unIdCliente")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .AgregarParametro();

        BP.CrearParametro("unNombre")
        .SetTipoVarchar(45)
        .SetValor(cliente.Nombre)
        .AgregarParametro();

        BP.CrearParametro("unApellido")
        .SetTipoVarchar(45)
        .SetValor(cliente.Apellido)
        .AgregarParametro();

        BP.CrearParametro("unEmail")
        .SetTipoVarchar(45)
        .SetValor(cliente.Email)
        .AgregarParametro();

        BP.CrearParametro("unaClave")
        .SetTipoChar(64)
        .SetValor(cliente.Clave)
        .AgregarParametro();
    }

    private void PostAltaCliente(Cliente cliente)
        => cliente.IdCliente = Convert.ToUInt16(GetParametro("unIdCliente").Value);

    // public List<Pedido> ObtenerPedidosDe(Cliente cliente) => ColeccionDesdeTabla();

}
