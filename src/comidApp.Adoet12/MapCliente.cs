using comidApp.Adoet12;
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;
using et12.edu.ar.AGBD.Mapeadores;

namespace comidApp.Adoet12;

    public abstract class MapCliente: Mapeador<Cliente>
    {
    protected MapCliente(AdoAGBD ado) : base(ado)
        {
        public ushort IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        }

    }
    

