using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12;

public class AdoComidApp : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapCliente MapCliente { get; set; }
    public AdoComidApp(AdoAGBD ado)
    {
        Ado = ado;
        MapCliente = new MapCliente(Ado);
    }
    public void AltaCliente(Cliente cliente)
        => MapCliente.AltaCliente(cliente);

    public List<Cliente> ObtenerCliente()
        => MapCliente.ColeccionDesdeTabla();
}