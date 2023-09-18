using comidApp.Adoet12;

namespace comidApp.Core;

public class Servicio
{
    private readonly IAdo _ado;
    public Servicio(IAdo ado) => _ado = ado;

    public void AltaCliente(Cliente cliente)
    {
        if (cliente.IdCliente != 0)
            throw new ArgumentException("IdCliente no puede ser distinto de cero");
        
        //Validando cadenas
        if (    string.IsNullOrEmpty(cliente.Apellido)
            || string.IsNullOrEmpty(cliente.Nombre)
            || string.IsNullOrEmpty(cliente.Email)
        )
            throw new ArgumentException("Las cadenas no puede estar vacias");
        
        _ado.AltaCliente(cliente);
    }

    public List<Cliente> ObtenerCliente() => _ado.ObtenerCliente();

}
