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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}