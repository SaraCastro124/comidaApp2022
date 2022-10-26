using System.Data;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;
public class MapRestaurante : Mapeador<Restaurante>
{
    public MapRestaurante(AdoAGBD ado) : base(ado)
    {
    }

    public override Restaurante ObjetoDesdeFila(DataRow fila)
    {
        throw new NotImplementedException();
    }
}