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

    public void AltaRestaurante(Restaurante restaurante)
    {
        if(restaurante.idRestaurante != 0)
            throw new ArgumentException("idRestaurante no puede ser distinto de cero");

        if (string.IsNullOrEmpty(restaurante.Email)
            || string.IsNullOrEmpty(restaurante.Nombre)
            || string.IsNullOrEmpty(restaurante.Domicilio)
        )
            throw new ArgumentException("las cadenas no pueden estar vacias");

        _ado.AltaRestaurante(restaurante);
    }
    public List<Restaurante> ObtenerRestaurante() => _ado.ObtenerRestaurante();

}
