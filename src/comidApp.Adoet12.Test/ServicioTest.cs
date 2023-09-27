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
    public void AltaClienteOK()
    {
        Cliente cliente = new Cliente(IdCliente: 0, nombre: "ojo", apellido: "hfsu", email: "gatito@gmail.com", clave: "123456");
        
        //TODO usar mock o crear el .json para conectarse la BD
        _servicio.AltaCliente(cliente);
        Assert.NotEqual(0, cliente.IdCliente);
    }

    [Fact]
    public void AltaClienteFail()
    {
        Cliente cliente = new Cliente(IdCliente: 8, nombre: "", apellido: "", email: "gatito@gmail.com", clave: "123456");
        
        var execp = Assert.Throws<ArgumentException>(()=>_servicio.AltaCliente(cliente));
    }

    [Fact]
    public void AltaRestauranteOK()
    {
        Restaurante restaurante = new Restaurante(idRestaurante: 0, email: "totoro@gmail.com", nombre: "Resto Totoro", domicilio: "dnfdjlk 127", clave: "123456");

        _servicio.AltaRestaurante(restaurante);
        Assert.NotEqual(0, restaurante.idRestaurante);
    }

    [Fact]
    public void AltaRestauranteFail()
    {
        Restaurante restaurante = new Restaurante(idRestaurante: 1, email: "", nombre: "Resto Totoro", domicilio: "dnfdjlk 127", clave: "123456");

        var execp = Assert.Throws<ArgumentException>(()=>_servicio.AltaRestaurante(restaurante));
    }

    [Fact]
    public void AltaPlatoOK()
    {
        Plato plato = new Plato(nombre: "Arroz con palta", descripcion: "Palta con arroz", idPlato: 0, precioUnitario: 135.78, idRestaurante: 2, disponibilidad: 5);

        _servicio.AltaPlato(plato);
        Assert.NotEqual(0, plato.idPlato);
    }

    [Fact]
    public void AltaPlatoFail()
    {
        Plato plato = new Plato(nombre: "", descripcion: "Palta con arroz", idPlato: 1, precioUnitario: 135.78, idRestaurante: 0, disponibilidad: 8);
        var execp = Assert.Throws<ArgumentException>(()=>_servicio.AltaPlato(plato));
    }

    [Fact]
    public void AltaPedidoOK()
    {
        Pedido pedido = new Pedido(idRestaurante: 1, NroPedido: 0, fechaHora: DateTime.Now, idCliente: 1, precio: 27.22, opinion: 8, descripcion: "si");
        
        _servicio.AltaPedido(pedido);
        Assert.NotEqual(0, pedido.NroPedido);
    }

    [Fact]
    public void AltaPedidoFail()
    {
        Pedido pedido = new Pedido(idRestaurante: 1, NroPedido: 3, fechaHora: DateTime.Now, idCliente: 2, precio: 12.23, opinion: 2, descripcion: "");
        var execp = Assert.Throws<ArgumentException>(()=>_servicio.AltaPedido(pedido));
    }

}
