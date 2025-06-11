using KProyecto.EF;
using KProyecto.Models;
using System.Linq;
using System.Web.Mvc;

namespace KProyecto.Controllers
{
    public class HomeController : Controller
    {

        #region Index

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Autenticacion autenticacion)
        {
            using (var dbContext = new KNDataBaseEntities())
            {
                //var result = dbContext.TUsuario.FirstOrDefault(u => u.NombreUsuario == autenticacion.NombreUsuario
                //                                                 && u.Contrasenna == autenticacion.Contrasenna);

                var result = dbContext.ValidarInicioSesion(
                    autenticacion.NombreUsuario, 
                    autenticacion.Contrasenna).FirstOrDefault();

                if (result != null)
                    return RedirectToAction("Principal", "Home");

                ViewBag.Mensaje = "No se pudo validar su información";
                return View();
            }
        }

        #endregion

        #region Registro

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Autenticacion autenticacion)
        {
            using (var dbContext = new KNDataBaseEntities())
            {
                //dbContext.TUsuario.Add(new TUsuario
                //{
                //    Nombre = autenticacion.Nombre,
                //    Correo = autenticacion.Correo,
                //    NombreUsuario = autenticacion.NombreUsuario,
                //    Contrasenna = autenticacion.Contrasenna
                //});

                //var result = dbContext.SaveChanges();

                var result = dbContext.RegistroUsuario(
                    autenticacion.Nombre,
                    autenticacion.Correo,
                    autenticacion.NombreUsuario,
                    autenticacion.Contrasenna);

                if (result > 0)
                    return RedirectToAction("Index", "Home");

                ViewBag.Mensaje = "No se pudo registrar su información";
                return View();
            }
        }

        #endregion

        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }

    }
}