using comidApp.Core;
using Microsoft.AspNetCore.Mvc;

namespace comidApp.MVC.Controllers;
public class RestauranteController : Controller
{
    private readonly Servicio _servicio;
    public RestauranteController(Servicio servicio) => _servicio = servicio;

    [HttpGet]
    public IActionResult Alta() => View();

    [HttpPost]
    public IActionResult Alta(Restaurante restaurante)
    {
        try
        {
            _servicio.AltaRestaurante(restaurante);
            return RedirectToAction(nameof(Alta));
        }
        catch (System.Exception)
        {
            return NotFound();
            throw;
        }
        
    }
}