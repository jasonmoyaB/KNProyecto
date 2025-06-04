using KProyecto.Models;
using System.Web.Mvc;

namespace KProyecto.Controllers
{
    public class HomeController : Controller
    {
        //Abrir las vistas
        [HttpGet] 
        public ActionResult Index()
        {
            return View();
        }

        //Ejecutan acciones con botones de tipo submit
        [HttpPost] 
        public ActionResult Index(Autenticacion autenticacion)
        {
            return View();
        }

        public ActionResult Principal()
        {
            return View();
        }

    }
}