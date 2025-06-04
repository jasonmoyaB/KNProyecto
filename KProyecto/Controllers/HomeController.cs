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
            /**/

            ViewBag.Mensaje = "No se pudo validar su información";
            return View();
            //return RedirectToAction("Principal", "Home");
        }


        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Autenticacion autenticacion)
        {
            /**/

            ViewBag.Mensaje = "No se pudo registrar su información";
            return View();
            //return RedirectToAction("Principal", "Home");
        }






        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }

    }
}