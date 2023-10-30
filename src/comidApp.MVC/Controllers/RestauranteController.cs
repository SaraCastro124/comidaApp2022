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
        //aca va la magia
        throw new NotImplementedException();
    }
}