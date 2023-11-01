using Microsoft.AspNetCore.Mvc;
using comidApp.Core;

namespace comidApp.MVC.Controllers;

public class ClienteController : Controller
{
    private readonly Servicio _servicio;
    public ClienteController(Servicio servicio) => _servicio = servicio;

    [HttpGet]
    public IActionResult AltaCliente() => View();

    [HttpPost]
    public IActionResult AltaCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

}
