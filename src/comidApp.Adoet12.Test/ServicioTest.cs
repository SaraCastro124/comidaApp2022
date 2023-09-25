using comidApp.Core;
using et12.edu.ar.AGBD.Ado;

namespace comidApp.Adoet12.Test;

public class ServicioTest
{
    private readonly Servicio _servicio;
    public ServicioTest()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        var ado = new AdoComidApp(adoAGBD);
        _servicio = new Servicio(ado);
    }

    [Fact]
    public void AltaCliente()
    {
        Cliente cliente = new Cliente(IdCliente: 0, nombre: "ojo", apellido: "hfsu", email: "gatito@gmail.com", clave: "123456");
        
        //TODO usar mock o crear el .json para conectarse la BD
        var execp = Assert.Throws<InvalidOperationException>(()=>_servicio.AltaCliente(cliente));
    }
}
