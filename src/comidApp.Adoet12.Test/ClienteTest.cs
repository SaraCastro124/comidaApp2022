
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
        var cliente = new Cliente(2, "Sara", "Castro", "sara@gmail", "a3");
        Ado.AltaCliente(cliente);
        Assert.Equal(2, Cliente.IdCliente);
    }

    [Theory]
    [InlineData(1, "Sara")]
    public void TraerClientes()
    {
        var Cliente = Ado.ObtenerCliente();
        Assert.Contains(Cliente, c => c.IdCliente == IdCliente && c.Nombre == Nombre);
    }

}