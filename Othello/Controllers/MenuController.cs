using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Othello.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Inicio()
        {

            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult PartidaIA()
        {
            return Redirect("~/Partida/Sala1");
        }

        public ActionResult PartidaVS()
        {
            return Redirect("~/Partida/Sala2");
        }

        public ActionResult Xtream()
        {
            return Redirect("~/Partida/OthelloXtream");
        }
    }
}