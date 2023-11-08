using comidApp.Core;
using Microsoft.AspNetCore.Mvc;

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
        try
        {
            _servicio.AltaCliente(cliente);
            return RedirectToAction(nameof(AltaCliente));
        }
        catch (System.Exception)
        {
            return NotFound();
            throw;
        }
    }

}
