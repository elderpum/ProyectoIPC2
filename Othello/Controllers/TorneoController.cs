using Othello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Othello.Controllers
{
    public class TorneoController : Controller
    {
        // GET: Torneo
        static List<Pieza> listaGeneral = new List<Pieza>();
        static bool turno = true;
        public ActionResult Index()
        {
            for (int i = 0; i < 64; i++)
            {
                Pieza pieza = new Pieza(i);
                listaGeneral.Add(pieza);

                if (i == 27 || i == 36)
                {
                    listaGeneral[i].Color = "black";
                }
                else if (i == 28 || i == 35)
                {
                    listaGeneral[i].Color = "white";
                }
                else
                {
                    listaGeneral[i].Color = null;
                }
            }
            turno = true;
            return View(listaGeneral);
        }
    }
}