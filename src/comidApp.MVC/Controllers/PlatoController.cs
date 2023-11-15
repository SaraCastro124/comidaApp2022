using comidApp.Core;
using comidApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace comidApp.MVC.Controllers;
public class PlatoController : Controller
{
    private readonly Servicio _servicio;
    public PlatoController(Servicio servicio) => _servicio = servicio;

    public IActionResult Listado()
    {
        var platos = _servicio.ObtenerPlatos();
        return View(platos);
    }

    [HttpGet]
    public IActionResult AltaPlato()
    {
        var vmPlato = new PlatoViewModel(_servicio.ObtenerRestaurantes());
        return View(vmPlato);
    }

    [HttpPost]
    public async Task<IActionResult> AltaPlato(PlatoViewModel platoVM)
    {
        if (!ModelState.IsValid)
            return View("AltaPlato", platoVM);

        var plato = platoVM.Instancia;
        
        try
        {

            _servicio.AltaPlato(plato);
        }

        catch (System.Exception)
        {
            throw;
        }
        return RedirectToAction(nameof(Detalle), new { id = plato.idPlato });
    }
    public IActionResult Detalle(short id)
    {
        var plato = _servicio.ObtenerPlatos().FirstOrDefault(p => p.idPlato == id);

        if (plato is null)
        
            return NotFound();

        return View(plato);
    }

}
