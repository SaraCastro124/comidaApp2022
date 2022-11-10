using System.Data;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;
public class MapRestaurante : Mapeador<Restaurante>
{
    public MapRestaurante(AdoAGBD ado) : base(ado)
        => Tabla = "Restaurante";

    public override Restaurante ObjetoDesdeFila(DataRow fila)
            => new Restaurante(
            idRestaurante: Convert.ToByte(fila["IdRestaurante"]),
            email: fila["Email"].ToString()!,
            nombre: fila["Nombre"].ToString()!,
            domicilio: fila["Domicilio"].ToString()!,
            clave: fila["Clave"].ToString()!
        );

    public void AltaRestaurante(Restaurante restaurante)
    {
        EjecutarComandoCon("AltaRestaurante", ConfigurarAltaRestaurante, PostAltaRestaurante, restaurante);
    }

    private void ConfigurarAltaRestaurante(Restaurante restaurante)
    {
        SetComandoSP("AltaRestaurante");

        BP.CrearParametroSalida("unIdRestaurante")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .AgregarParametro();

        BP.CrearParametro("unEmail")
        .SetTipoVarchar(45)
        .SetValor(restaurante.Email)
        .AgregarParametro();

        BP.CrearParametro("unNombre")
        .SetTipoVarchar(50)
        .SetValor(restaurante.Nombre)
        .AgregarParametro();

        BP.CrearParametro("unDomicilio")
        .SetTipoVarchar(45)
        .SetValor(restaurante.Domicilio)
        .AgregarParametro();

        BP.CrearParametro("unaClave")
        .SetTipoChar(64)
        .SetValor(restaurante.Clave)
        .AgregarParametro();
    }

    private void PostAltaRestaurante(Restaurante restaurante)
        => restaurante.idRestaurante = Convert.ToUInt16(GetParametro("unIdRestaurante").Value);
}