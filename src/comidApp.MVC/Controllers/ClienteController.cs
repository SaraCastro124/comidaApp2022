using Microsoft.AspNetCore.Mvc;
namespace comidApp.MVC.Controllers;

public class ClienteController : Controller
{
    public ClienteController()
    {
        
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
