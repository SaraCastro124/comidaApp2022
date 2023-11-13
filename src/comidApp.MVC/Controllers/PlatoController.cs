using comidApp.Core;
using comidApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace comidApp.MVC.Controllers;
public class PlatoController : Controller
{
    private readonly Servicio _servicio;
    public PlatoController(Servicio servicio) => _servicio = servicio;

    [HttpGet]
    public IActionResult AltaPlato() => View();

    [HttpPost]
    public async Task<IActionResult> (PlatoViewModel platoVM)
    {
        if ()
        try
        {
            _servicio.AltaPlato(platoVM);
            return RedirectToAction("Detalle", "Restaurante", platoVM.IdRestaurante);
        }
        catch (System.Exception)
        {
            return NotFound();
            throw;
        }
    }
}
