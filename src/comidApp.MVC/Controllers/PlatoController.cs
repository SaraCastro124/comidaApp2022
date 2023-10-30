using comidApp.Core;
using Microsoft.AspNetCore.Mvc;

namespace comidApp.MVC.Controllers;
public class PlatoController : Controller
{
    private readonly Servicio _servicio;
    public PlatoController(Servicio servicio) => _servicio = servicio;

    [HttpGet]
    public IActionResult AltaPlato() => View();

    [HttpPost]
    public IActionResult AltaPlato(Plato plato)
    {
        throw new NotImplementedException();
    }
}
