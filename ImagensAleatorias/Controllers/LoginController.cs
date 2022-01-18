using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagensAleatorias.Controllers
{
    public class LoginController : Controller
    {
        ImagensAleatoriasEntities2 db = new ImagensAleatoriasEntities2();

        // GET: Login
        public ActionResult Index()
        {
            if (Session["Login"] != null)
            {
                return RedirectToAction("../Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            var login = db.Usuario.Where(a => a.usuario1.Equals(usuario.usuario1) && a.senha.Equals(usuario.senha)).FirstOrDefault();

            if (login != null)
            {
                Session["Login"] = true;
                Session["Usuario"] = login.usuario1.ToString();
                Session["UsuarioID"] = login.id.ToString();
                if (login.cargo == "ADM")
                {
                    Session["UsuarioCargo"] = "ADM";
                }
                else
                {
                    Session["UsuarioCargo"] = null;
                }
            }
            return RedirectToAction("../Home");
        }

        public ActionResult Logout()
        {
            Session["Login"] = null;
            Session["Usuario"] = null;
            Session["UsuarioID"] = null;

            return RedirectToAction("../Login");
        }
    }
}