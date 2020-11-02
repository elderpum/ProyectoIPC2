using Othello.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Othello.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Usuario usuario)
        {
            try
            {
                using (IPC2_2S2020Entities db = new IPC2_2S2020Entities())
                {
                    var lst = from a in db.Usuario
                              where a.NombreUser == usuario.NombreUser && a.Contraseña == usuario.Contraseña
                              select a;
                    if (lst.Count() > 0)
                    {
                        Usuario oUser = lst.First();
                        Session["Usuarios"] = oUser;
                        System.Web.HttpContext.Current.Session["login"] = oUser.NombreUser;
                        return Redirect("~/Menu/Inicio");
                    }
                    else
                    {
                        return Redirect("~/Login/Index");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Redirect("~/Login/Index");
            }
        }
    }
}