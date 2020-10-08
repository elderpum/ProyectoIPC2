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
        static List<Pieza> listaGeneral = new List<Pieza>();
        // GET: Tablero
        public ActionResult Sala1()
        {
            for (int i = 0; i < 10; i++)
            {
                Pieza pieza = new Pieza();
                pieza.ID = 0;
                listaGeneral.Add(pieza);
            }
            return View(listaGeneral);
        }

        public ActionResult CambioFicha(string io)
        {
            Boolean turno = false; //Cuando sea falsa, es el turno del negro. Cuando sea verdadera, es el turno del blanco.
            int indice = Int32.Parse(io);
            if (listaGeneral[indice].Color is null && turno == false)
            {
                listaGeneral[indice].Color = "black";
                turno = true;
            }
            else if (listaGeneral[indice].Color is null && turno)
            {
                listaGeneral[indice].Color = "white";
                turno = false;
            }
            else
            {
                if (listaGeneral[indice].Color == "black" && turno)
                {
                    listaGeneral[indice].Color = "white";
                    turno = false;
                }
                else
                {
                    listaGeneral[indice].Color = "black";
                    turno = true;
                }
            }
            return View("indice", listaGeneral);
        }

        public ActionResult CargaArchivo(HttpPostedFileBase doc)
        {
            if (doc.ContentLength > 0 && doc != null)
            {
                TempData["file"] = doc.FileName;
            }
            return View("ID", listaGeneral);
        }
    }
}