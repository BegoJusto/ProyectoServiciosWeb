using ProyectosServiciosWeb.BBLL;
using ProyectosServiciosWeb.BBLL.interfaces;
using ProyectosServiciosWeb.Models;

using System.Collections.Generic;
using System.Web.Mvc;


namespace ProyectosServiciosWeb.Controllers {
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private AutorService es = new AutorServiceImp();
        private LibroService lS = new LibroServiceImp();
        //Esto es como el requestyMapping de spring
        // GET: Home
        public ActionResult Index()
        {
            
            ViewBag.Message = "Bienvenido a la gestión de bibliotecas";
            IList<Libro> libros = lS.getAll();
            
            return View(libros);
        }

        //GET : About
        public ActionResult About()
        {
            
            return View();
        }
    }
}