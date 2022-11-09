
using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class ClienteTest
{
    public AdoComidApp Ado{get; set;}
    public ClienteTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoComidApp(adoAGBD);
    }
    
    [Fact]
    public void registrarCliente()
    {
        Cliente cliente = new Cliente(1000, "Sara", "Castro","sara@gmail.com", "s4");
        Ado.AltaCliente(cliente);
        Assert.Equal(2, cliente.IdCliente);
    }

    [Fact]
    public void TraerCliente()
    {
        var clientes = Ado.ObtenerCliente();
        Assert.Contains(clientes, c => c.IdCliente == 1 && c.Nombre == "Abril");
    }
}