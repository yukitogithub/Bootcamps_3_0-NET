using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_WebASPNETCore_MVC.Models;

namespace WebApplication_WebASPNETCore_MVC.Controllers
{
    //Nombre del Controlador:
    //1-Afecta a la URL de la petici�n
    //2-Afecta al nombre de la carpeta de las vistas
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; //Field Privado de solo lectura

        //Constructor
        public HomeController(ILogger<HomeController> logger) //Inyecci�n de dependencias
        {
            //Inyecci�n por constructor
            _logger = logger;
        }

        //Devuelve cualquier clase que Implementa IActionResult
        //M�todo acci�n del controlador
        //Devuelve una vista
        //Nombre de la acci�n:
        //1-Afecta a la URL de la petici�n
        //2-Afecta al nombre del archivo de la vista
        public IActionResult Index()
        {
            return View(); //ViewResult
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //return View(); //Tira error, porque no existe la vista Error
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
