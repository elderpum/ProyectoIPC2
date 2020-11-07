using Othello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Othello.Controllers
{
    public class MenuController : Controller
    {
        static string J2N = "";
        static string modoN = "";
        static string J2X = "";
        static string modoX = "";
        static string j1c1 = "";
        static string j1c2 = "";
        static string j1c3 = "";
        static string j1c4 = "";
        static string j1c5 = "";
        static string j2c1 = "";
        static string j2c2 = "";
        static string j2c3 = "";
        static string j2c4 = "";
        static string j2c5 = "";
        static string fila = "";
        static string columna = "";
        static string tipoApertura = "";
        // GET: Menu
        public ActionResult Inicio()
        {

            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult PreOthello()
        {
            return View();
        }

        public ActionResult PreOthelloXtream()
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
        [HttpPost]
        public ActionResult Tablero(TableroNormal tablero)
        {
            string nombre = tablero.nombreJ2;
            string modo = tablero.modo;
            if (nombre != null && modo != null)
            {
                J2N = nombre;
                System.Web.HttpContext.Current.Session["J2N"] = J2N;
                modoN = modo;
                System.Web.HttpContext.Current.Session["modoN"] = modoN;
                return Redirect("~/Partida/Sala1");
            }
            else
            {
                return Redirect("~/Menu/PreOthello");
            }
        }
        [HttpPost]
        public ActionResult TableroD(TableroDinamico tablero)
        {
            string nombre = tablero.nombreJ2;
            string modo = tablero.modo;
            string j1color1 = tablero.j1c1;
            string j1color2 = tablero.j1c2;
            string j1color3 = tablero.j1c3;
            string j1color4 = tablero.j1c4;
            string j1color5 = tablero.j1c5;
            string j2color1 = tablero.j2c1;
            string j2color2 = tablero.j2c2;
            string j2color3 = tablero.j2c3;
            string j2color4 = tablero.j2c4;
            string j2color5 = tablero.j2c5;
            string filas = tablero.fila;
            string columnas = tablero.columna;
            string apertura = tablero.apertura;
            if (nombre != null && modo !=null)
            {
                if (j1color1 != null && j1color2 != null && j1color3 != null && j1color4 != null && j1color5 != null && j2color1 != null && j2color2 != null && j2color3 != null && j2color4 != null && j2color5 != null)
                {
                    j1c1 = j1color1;
                    System.Web.HttpContext.Current.Session["j1c1"] = j1c1;
                    j1c2 = j1color2;
                    System.Web.HttpContext.Current.Session["j1c2"] = j1c2;
                    j1c3 = j1color3;
                    System.Web.HttpContext.Current.Session["j1c3"] = j1c3;
                    j1c4 = j1color4;
                    System.Web.HttpContext.Current.Session["j1c4"] = j1c4;
                    j1c5 = j1color5;
                    System.Web.HttpContext.Current.Session["j1c5"] = j1c5;
                    j2c1 = j2color1;
                    System.Web.HttpContext.Current.Session["j2c1"] = j2c1;
                    j2c2 = j2color2;
                    System.Web.HttpContext.Current.Session["j2c2"] = j2c2;
                    j2c3 = j2color3;
                    System.Web.HttpContext.Current.Session["j2c3"] = j2c3;
                    j2c4 = j2color4;
                    System.Web.HttpContext.Current.Session["j2c4"] = j2c4;
                    j2c5 = j2color5;
                    System.Web.HttpContext.Current.Session["j2c5"] = j2c5;
                    J2X = nombre;
                    System.Web.HttpContext.Current.Session["J2X"] = J2X;
                    modoX = modo;
                    System.Web.HttpContext.Current.Session["modoX"] = modoX;
                    fila = filas;
                    System.Web.HttpContext.Current.Session["fila"] = fila;
                    columna = columnas;
                    System.Web.HttpContext.Current.Session["columna"] = columna;
                    tipoApertura = apertura;
                    System.Web.HttpContext.Current.Session["apertura"] = tipoApertura;
                    return Redirect("~/Partida/OthelloXtream");
                }
                else
                {
                    return Redirect("~/Menu/PreOthelloXtream");
                }
            }
            else
            {
                return Redirect("~/Menu/PreOthelloXtream");
            }
        }
    }
}