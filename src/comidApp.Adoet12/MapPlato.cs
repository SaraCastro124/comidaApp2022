using System.Data;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;

public class MapPlato : Mapeador<Plato>
{

    public MapPlato(AdoAGBD ado) : base(ado)
            => Tabla = "Plato";

    public override Plato ObjetoDesdeFila(DataRow fila)
        => new Plato(
            nombre: fila["nombre"].ToString()!,
            descripcion: fila["descripcion"].ToString()!,
            idPlato: Convert.ToUInt16(fila["idPlato"]),
            precioUnitario: Convert.ToDouble(fila["precioUnitario"]),
            idRestaurante: Convert.ToUInt16(fila["idRestaurante"]),
            disponibilidad: Convert.ToUInt16(fila["disponibilidad"])
        );

    public void AltaPlato(Plato plato)
    {
        EjecutarComandoCon("AltaPlato", ConfigurarAltaPlato, PostAltaPlato, plato);
    }

    private void ConfigurarAltaPlato(Plato plato)
    {
        SetComandoSP("AltaPlato");

        BP.CrearParametro("unNombre")
        .SetTipoVarchar(50)
        .SetValor(plato.Nombre)
        .AgregarParametro();

        BP.CrearParametro("unaDescripcion")
        .SetTipoVarchar(45)
        .SetValor(plato.Descripcion)
        .AgregarParametro();

        BP.CrearParametroSalida("unIdPlato")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(plato.idPlato)
        .AgregarParametro();

        BP.CrearParametro("unPrecioUnitario")
        .SetTipoDecimal(7, 2)
        .SetValor(plato.PrecioUnitario)
        .AgregarParametro();

        BP.CrearParametro("unIdRestaurante")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(plato.IdRestaurante)
        .AgregarParametro();

        BP.CrearParametro("unaDisponibilidad")
        .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
        .SetValor(plato.Disponibilidad)
        .AgregarParametro();
    }
    private void PostAltaPlato(Plato plato)
        => plato.idPlato = Convert.ToUInt16(GetParametro("unIdPlato").Value);


}