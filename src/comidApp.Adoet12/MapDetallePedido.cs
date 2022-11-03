
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;

    public class MapDetallePedido : Mapeador<detallePedido>
    {
        public MapDetallePedido(AdoAGBD ado) : base(ado)
            => Tabla = "Detalla "
    }
