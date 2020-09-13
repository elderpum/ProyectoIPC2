using Othello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Othello.Controllers
{
    public class PartidaController : Controller
    {
        // GET: Tablero
        [HttpGet]
        public ActionResult Sala()
        {
            return View();
        }
    }
}