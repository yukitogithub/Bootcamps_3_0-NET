using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_WebASPNETCore_MVC.Models;

namespace WebApplication_WebASPNETCore_MVC.Controllers
{
    //Persona debe tener una carpeta en Views con el mismo nombre
    public class PersonaController : Controller
    {
        public static List<Persona> personas { get; set; }

        public PersonaController()
        {
            personas = new List<Persona>();
            personas.Add(new Persona { Id = 1, Nombre = "Juan", Apellido = "Perez", Edad = 30, Dni = "12345678", Email = "lsdfhhsdf@sdflkjsdf.com" }); ;
            personas.Add(new Persona { Id = 2, Nombre = "Maria", Apellido = "Gomez", Edad = 25, Dni = "87654321", Email = "dfgdfg@mail.com" });
        }

        // GET: PersonaController
        //La carpeta Persona debe tener un archivo Index.cshtml
        public ActionResult Index()
        {
            return View(personas);
        }

        // GET: PersonaController/Details/5
        //La carpeta Persona debe tener un archivo Details.cshtml
        //El parámetro id se recibe por la URL
        //El parámetro id afecta a la URL de la petició
        //Ejemplo de URL: https://localhost:44300/Persona/Details/5
        //NombreControlador/NombreAccion/Parametro
        public ActionResult Details(int id)
        {
            var persona = personas.FirstOrDefault(x => x.Id == id);
            return View(persona);
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
