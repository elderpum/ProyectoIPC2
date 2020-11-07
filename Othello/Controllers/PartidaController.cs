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
        //Pieza pieza = new Pieza();
        static bool turno = true; //Cuando sea verdadera, es el turno del negro. Cuando sea falsa, es el turno del blanco.
        static List<Pieza> listaGeneral = new List<Pieza>();
        static List<string> coloresJ1 = new List<string>();
        static List<string> coloresJ2 = new List<string>();
        // GET: Tablero
        public ActionResult Sala1()
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

        public ActionResult OthelloXtream()
        {
            int columnas = Int32.Parse(System.Web.HttpContext.Current.Session["columna"].ToString());
            int filas = Int32.Parse(System.Web.HttpContext.Current.Session["fila"].ToString());
            int total = columnas * filas;
            string j1c1 = System.Web.HttpContext.Current.Session["j1c1"].ToString();
            string j1c2 = System.Web.HttpContext.Current.Session["j1c2"].ToString();
            string j1c3 = System.Web.HttpContext.Current.Session["j1c3"].ToString();
            string j1c4 = System.Web.HttpContext.Current.Session["j1c4"].ToString();
            string j1c5 = System.Web.HttpContext.Current.Session["j1c5"].ToString();
            string j2c1 = System.Web.HttpContext.Current.Session["j2c1"].ToString();
            string j2c2 = System.Web.HttpContext.Current.Session["j2c2"].ToString();
            string j2c3 = System.Web.HttpContext.Current.Session["j2c3"].ToString();
            string j2c4 = System.Web.HttpContext.Current.Session["j2c4"].ToString();
            string j2c5 = System.Web.HttpContext.Current.Session["j2c5"].ToString();
            for (int i = 0; i < total; i++)
            {
                Pieza pieza = new Pieza(i);
                listaGeneral.Add(pieza);
                listaGeneral[i].Color = null;
            }
            turno = true;
            if (j1c1 == "Negro" || j1c1 == "Blanco" || j1c1 == "Azul" || j1c1 == "Rojo" || j1c1 == "Amarillo" || j1c1 == "Celeste" || j1c1 == "Verde" || j1c1 == "Violeta" || j1c1 == "Gris" || j1c1 == "Anaranjado")
            {
                coloresJ1.Add(j1c1);
            }
            if (j1c2 == "Negro" || j1c2 == "Blanco" || j1c2 == "Azul" || j1c2 == "Rojo" || j1c2 == "Amarillo" || j1c2 == "Celeste" || j1c2 == "Verde" || j1c2 == "Violeta" || j1c2 == "Gris" || j1c2 == "Anaranjado")
            {
                coloresJ1.Add(j1c2);
            }
            if (j1c3 == "Negro" || j1c3 == "Blanco" || j1c3 == "Azul" || j1c3 == "Rojo" || j1c3 == "Amarillo" || j1c3 == "Celeste" || j1c3 == "Verde" || j1c3 == "Violeta" || j1c3 == "Gris" || j1c3 == "Anaranjado")
            {
                coloresJ1.Add(j1c3);
            }
            if (j1c4 == "Negro" || j1c4 == "Blanco" || j1c4 == "Azul" || j1c4 == "Rojo" || j1c4 == "Amarillo" || j1c4 == "Celeste" || j1c4 == "Verde" || j1c4 == "Violeta" || j1c4 == "Gris" || j1c4 == "Anaranjado")
            {
                coloresJ1.Add(j1c4);
            }
            if (j1c5 == "Negro" || j1c5 == "Blanco" || j1c5 == "Azul" || j1c5 == "Rojo" || j1c5 == "Amarillo" || j1c5 == "Celeste" || j1c5 == "Verde" || j1c5 == "Violeta" || j1c5 == "Gris" || j1c5 == "Anaranjado")
            {
                coloresJ1.Add(j1c5);
            }
            if (j2c1 == "Negro" || j2c1 == "Blanco" || j2c1 == "Azul" || j2c1 == "Rojo" || j2c1 == "Amarillo" || j2c1 == "Celeste" || j2c1 == "Verde" || j2c1 == "Violeta" || j2c1 == "Gris" || j2c1 == "Anaranjado")
            {
                coloresJ2.Add(j2c1);
            }
            if (j2c2 == "Negro" || j2c2 == "Blanco" || j2c2 == "Azul" || j2c2 == "Rojo" || j2c2 == "Amarillo" || j2c2 == "Celeste" || j2c2 == "Verde" || j2c2 == "Violeta" || j2c2 == "Gris" || j2c2 == "Anaranjado")
            {
                coloresJ2.Add(j2c2);
            }
            if (j2c3 == "Negro" || j2c3 == "Blanco" || j2c3 == "Azul" || j2c3 == "Rojo" || j2c3 == "Amarillo" || j2c3 == "Celeste" || j2c3 == "Verde" || j2c3 == "Violeta" || j2c3 == "Gris" || j2c3 == "Anaranjado")
            {
                coloresJ2.Add(j2c3);
            }
            if (j2c4 == "Negro" || j2c4 == "Blanco" || j2c4 == "Azul" || j2c4 == "Rojo" || j2c4 == "Amarillo" || j2c4 == "Celeste" || j2c4 == "Verde" || j2c4 == "Violeta" || j2c4 == "Gris" || j2c4 == "Anaranjado")
            {
                coloresJ2.Add(j2c4);
            }
            if (j2c5 == "Negro" || j2c5 == "Blanco" || j2c5 == "Azul" || j2c5 == "Rojo" || j2c5 == "Amarillo" || j2c5 == "Celeste" || j2c5 == "Verde" || j2c5 == "Violeta" || j2c5 == "Gris" || j2c5 == "Anaranjado")
            {
                coloresJ2.Add(j2c5);
            }
            return View(listaGeneral);
        }
        public ActionResult Redirect()
        {
            return Redirect("~/Partida/OthelloXtream");
        }
        public void Cronometro()
        {
            TimeSpan inicio = (TimeSpan)TempData["empezar"];
            TimeSpan fin = DateTime.Now.TimeOfDay;
            TimeSpan tiempo = fin - inicio;
            if (turno)
            {
                ViewBag.CronometroNegro = tiempo;
            }
            else
            {
                ViewBag.CronometroBlanco = tiempo;
            }
        }

        public ActionResult CambioFicha(string io)
        {
            string modoN = System.Web.HttpContext.Current.Session["modoN"].ToString();
            int contadorNegras = 0;
            int contadorBlancas = 0;
            bool encierra = false;
            List<Pieza> listaFichasCambiar = new List<Pieza>();
            int indice = Int32.Parse(io);
            //Cuando se pulsa un botón, vamos a obtener las posiciones de los botones adyacentes al que pulsamos en todas las direcciones y vamos a evaluar si existe una ficha del color rival
            int norte = indice - 8;
            int noroeste = indice - 7;
            int oeste = indice + 1;
            int suroeste = indice + 9;
            int sur = indice + 8;
            int sureste = indice + 7;
            int este = indice - 1;
            int noreste = indice - 9;

            //El problema de validar esto, es que en los laterales al ir al este puede pasar a la siguiente fila de botones, eso hay que restringirlo haciendo casos exclusivos para ciertos ID's
            #region
            if (indice == 0)
            {
                norte = -1;
                noreste = -1;
                este = -1;
                sureste = -1;
                noroeste = -1;

            }
            else if (indice == 1 || indice == 2 || indice == 3 || indice == 4 || indice == 5 || indice == 6)
            {
                noreste = -1;
                norte = -1;
                noroeste = -1;
            }
            else if (indice == 7)
            {
                noreste = -1;
                norte = -1;
                noroeste = -1;
                oeste = -1;
                suroeste = -1;
            }
            else if (indice == 8 || indice == 16 || indice == 24 || indice == 32 || indice == 40 || indice == 48)
            {
                noreste = -1;
                este = -1;
                sureste = -1;
            }
            else if (indice == 15 || indice == 23 || indice == 31 || indice == 39 || indice == 47 || indice == 55)
            {
                noroeste = -1;
                oeste = -1;
                suroeste = -1;
            }
            else if (indice == 57 || indice == 58 || indice == 59 || indice == 60 || indice == 61 || indice == 62)
            {
                sureste = -1;
                sur = -1;
                suroeste = -1;
            }
            else if (indice == 56)
            {
                noreste = -1;
                este = -1;
                sureste = -1;
                sur = -1;
                suroeste = -1;
            }
            else if (indice == 63)
            {
                sureste = -1;
                sur = -1;
                suroeste = -1;
                oeste = -1;
                noroeste = -1;
            }
            #endregion

            //Acá validamos las 8 direcciones para cambiar de color una ficha
            #region 
            //Primero evaluamos si alguna ficha puede cambiar de color antes de asignarle uno
            if (norte >= 0 && listaGeneral[norte].Color != null) //que sea mayor al borde del tablero
            {
                while (norte >= 0 && norte < 64)
                {
                    if (turno)
                    {
                        if (listaGeneral[norte].Color == "white")
                        {
                            Pieza ficha = listaGeneral[norte];
                            listaFichasCambiar.Add(ficha);
                            norte = norte - 8;
                        }
                        else if (listaGeneral[norte].Color == "black")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (listaGeneral[norte].Color == "black")
                        {
                            Pieza ficha = listaGeneral[norte];
                            listaFichasCambiar.Add(ficha);
                            norte = norte - 8;
                        }
                        else if (listaGeneral[norte].Color == "white")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (noroeste >= 0 && listaGeneral[noroeste].Color != null) //que sea mayor al borde del tablero
            {
                while (noroeste >= 0 && noroeste < 64)
                {
                    if (turno)
                    {
                        if (listaGeneral[noroeste].Color == "white")
                        {
                            Pieza ficha = listaGeneral[noroeste];
                            listaFichasCambiar.Add(ficha);
                            noroeste = noroeste - 7;
                        }
                        else if (listaGeneral[noroeste].Color == "black")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (listaGeneral[noroeste].Color == "black")
                        {
                            Pieza ficha = listaGeneral[noroeste];
                            listaFichasCambiar.Add(ficha);
                            noroeste = noroeste - 7;
                        }
                        else if (listaGeneral[noroeste].Color == "white")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (oeste >= 0 && listaGeneral[oeste].Color != null) //que sea mayor al borde del tablero
            {
                while (oeste >= 0 && oeste < 64)
                {
                    if (turno)
                    {
                        if (listaGeneral[oeste].Color == "white")
                        {
                            Pieza ficha = listaGeneral[oeste];
                            listaFichasCambiar.Add(ficha);
                            oeste = oeste + 1;
                        }
                        else if (listaGeneral[oeste].Color == "black")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (listaGeneral[oeste].Color == "black")
                        {
                            Pieza ficha = listaGeneral[oeste];
                            listaFichasCambiar.Add(ficha);
                            oeste = oeste + 1;
                        }
                        else if (listaGeneral[oeste].Color == "white")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (suroeste >= 0 && listaGeneral[suroeste].Color != null) //que sea mayor al borde del tablero
            {
                while (suroeste >= 0 && suroeste < 64)
                {
                    if (turno)
                    {
                        if (listaGeneral[suroeste].Color == "white")
                        {
                            Pieza ficha = listaGeneral[suroeste];
                            listaFichasCambiar.Add(ficha);
                            suroeste = suroeste + 9;
                        }
                        else if (listaGeneral[suroeste].Color == "black")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (listaGeneral[suroeste].Color == "black")
                        {
                            Pieza ficha = listaGeneral[suroeste];
                            listaFichasCambiar.Add(ficha);
                            suroeste = suroeste + 9;
                        }
                        else if (listaGeneral[suroeste].Color == "white")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (sur >= 0 && listaGeneral[sur].Color != null) //que sea mayor al borde del tablero
            {
                while (sur >= 0 && sur < 64)
                {
                    if (turno)
                    {
                        if (listaGeneral[sur].Color == "white")
                        {
                            Pieza ficha = listaGeneral[sur];
                            listaFichasCambiar.Add(ficha);
                            sur = sur + 8;
                        }
                        else if (listaGeneral[sur].Color == "black")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (listaGeneral[sur].Color == "black")
                        {
                            Pieza ficha = listaGeneral[sur];
                            listaFichasCambiar.Add(ficha);
                            sur = sur + 8;
                        }
                        else if (listaGeneral[sur].Color == "white")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (sureste >= 0 && listaGeneral[sureste].Color != null) //que sea mayor al borde del tablero
            {
                while (sureste >= 0 && sureste < 64)
                {
                    if (turno)
                    {
                        if (listaGeneral[sureste].Color == "white")
                        {
                            Pieza ficha = listaGeneral[sureste];
                            listaFichasCambiar.Add(ficha);
                            sureste = sureste + 7;
                        }
                        else if (listaGeneral[sureste].Color == "black")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (listaGeneral[sureste].Color == "black")
                        {
                            Pieza ficha = listaGeneral[sureste];
                            listaFichasCambiar.Add(ficha);
                            sureste = sureste + 7;
                        }
                        else if (listaGeneral[sureste].Color == "white")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (este >= 0 && listaGeneral[este].Color != null) //que sea mayor al borde del tablero
            {
                while (este >= 0 && este < 64)
                {
                    if (turno)
                    {
                        if (listaGeneral[este].Color == "white")
                        {
                            Pieza ficha = listaGeneral[este];
                            listaFichasCambiar.Add(ficha);
                            este = este - 1;
                        }
                        else if (listaGeneral[este].Color == "black")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (listaGeneral[este].Color == "black")
                        {
                            Pieza ficha = listaGeneral[este];
                            listaFichasCambiar.Add(ficha);
                            este = este - 1;
                        }
                        else if (listaGeneral[este].Color == "white")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (noreste >= 0 && listaGeneral[noreste].Color != null) //que sea mayor al borde del tablero
            {
                while (noreste >= 0 && noreste < 64)
                {
                    if (turno)
                    {
                        if (listaGeneral[noreste].Color == "white")
                        {
                            Pieza ficha = listaGeneral[noreste];
                            listaFichasCambiar.Add(ficha);
                            noreste = noreste - 9;
                        }
                        else if (listaGeneral[noreste].Color == "black")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (listaGeneral[noreste].Color == "black")
                        {
                            Pieza ficha = listaGeneral[noreste];
                            listaFichasCambiar.Add(ficha);
                            noreste = noreste - 9;
                        }
                        else if (listaGeneral[noreste].Color == "white")
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            #endregion

            if (listaGeneral[indice].Color is null && turno)
            {
                listaGeneral[indice].Color = "black";
                turno = false;
            }
            else if (listaGeneral[indice].Color is null && turno == false)
            {
                listaGeneral[indice].Color = "white";
                turno = true;
            }

            for (int i = 0; i < 64; i++)
            {
                if (listaGeneral[i].Color == "black")
                {
                    contadorNegras++;
                }
                else if (listaGeneral[i].Color == "white")
                {
                    contadorBlancas++;
                }
            }
            ViewBag.contadorNegras = contadorNegras;
            ViewBag.contadorBlancas = contadorBlancas;

            if (contadorNegras + contadorBlancas == 64)
            {
                if (modoN == "Reto Normal")
                {
                    if (contadorNegras > contadorBlancas)
                    {
                        ViewBag.Ganador = "El ganador es el Negro";
                    }
                    else
                    {
                        ViewBag.Ganador = "El ganador es el Blanco";
                    }
                }
                else
                {
                    if (contadorBlancas > contadorNegras)
                    {
                        ViewBag.Ganador = "El ganador es el Negro";
                    }
                    else
                    {
                        ViewBag.Ganador = "El ganador es el Blanco";
                    }
                }
            }
            Cronometro();
            return View("Sala1", listaGeneral);
        }

        public void validarColoresJ1(string io)
        {

        }
        public ActionResult CambioFichaXtream(string io)
        {
            string modoX = System.Web.HttpContext.Current.Session["modoX"].ToString();
            int columnas = Int32.Parse(System.Web.HttpContext.Current.Session["columna"].ToString());
            int filas = Int32.Parse(System.Web.HttpContext.Current.Session["fila"].ToString());
            int total = filas * columnas;
            int esquina1 = 0;
            int esquina2 = filas - 1;
            int esquina3 = total - (filas - 1);
            int esquina4 = total - 1;
            int contadorNegras = 0;
            int contadorBlancas = 0;
            bool encierra = false;
            List<Pieza> listaFichasCambiar = new List<Pieza>();
            int indice = Int32.Parse(io);
            //Cuando se pulsa un botón, vamos a obtener las posiciones de los botones adyacentes al que pulsamos en todas las direcciones y vamos a evaluar si existe una ficha del color rival
            int norte = indice - 8;
            int noroeste = indice - 7;
            int oeste = indice + 1;
            int suroeste = indice + 9;
            int sur = indice + 8;
            int sureste = indice + 7;
            int este = indice - 1;
            int noreste = indice - 9;

            //El problema de validar esto, es que en los laterales al ir al este puede pasar a la siguiente fila de botones, eso hay que restringirlo haciendo casos exclusivos para ciertos ID's
            #region
            if (indice == esquina1)
            {
                norte = -1;
                noreste = -1;
                este = -1;
                sureste = -1;
                noroeste = -1;

            }
            else if (indice > esquina1 && indice < esquina2)
            {
                noreste = -1;
                norte = -1;
                noroeste = -1;
            }
            else if (indice == esquina2)
            {
                noreste = -1;
                norte = -1;
                noroeste = -1;
                oeste = -1;
                suroeste = -1;
            }
            else if (indice > esquina1 && indice < esquina3)
            {
                int anterior = esquina1;
                while (indice > esquina1 && indice < esquina3)
                {
                    anterior = anterior + filas;
                    if (indice == anterior)
                    {
                        noreste = -1;
                        este = -1;
                        sureste = -1;
                        break;
                    }
                    else if (anterior > esquina3)
                    {
                        break;
                    }
                }
            }
            else if (indice > esquina2 && indice < esquina4)
            {
                int anterior = esquina2;
                while (indice > esquina2 && indice < esquina4)
                {
                    anterior = anterior + filas;
                    if (indice == anterior)
                    {
                        noroeste = -1;
                        oeste = -1;
                        suroeste = -1;
                        break;
                    }
                    else if (anterior > esquina4)
                    {
                        break;
                    }
                }
            }
            else if (indice > esquina3 && indice < esquina4)
            {
                sureste = -1;
                sur = -1;
                suroeste = -1;
            }
            else if (indice == esquina3)
            {
                noreste = -1;
                este = -1;
                sureste = -1;
                sur = -1;
                suroeste = -1;
            }
            else if (indice == esquina4)
            {
                sureste = -1;
                sur = -1;
                suroeste = -1;
                oeste = -1;
                noroeste = -1;
            }
            #endregion

            //Acá validamos las 8 direcciones para cambiar de color una ficha
            #region 
            //Primero evaluamos si alguna ficha puede cambiar de color antes de asignarle uno
            if (norte >= 0 && listaGeneral[norte].Color != null) //que sea mayor al borde del tablero
            {
                while (norte >= 0 && norte < 64)
                {
                    if (turno)
                    {
                        if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[norte];
                            listaFichasCambiar.Add(ficha);
                            norte = norte - 8;
                        }
                        else if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[norte];
                            listaFichasCambiar.Add(ficha);
                            norte = norte - 8;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (noroeste >= 0 && listaGeneral[noroeste].Color != null) //que sea mayor al borde del tablero
            {
                while (noroeste >= 0 && noroeste < 64)
                {
                    if (turno)
                    {
                        if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[noroeste];
                            listaFichasCambiar.Add(ficha);
                            noroeste = noroeste - 7;
                        }
                        else if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[noroeste];
                            listaFichasCambiar.Add(ficha);
                            noroeste = noroeste - 7;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (oeste >= 0 && listaGeneral[oeste].Color != null) //que sea mayor al borde del tablero
            {
                while (oeste >= 0 && oeste < 64)
                {
                    if (turno)
                    {
                        if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[oeste];
                            listaFichasCambiar.Add(ficha);
                            oeste = oeste + 1;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[oeste];
                            listaFichasCambiar.Add(ficha);
                            oeste = oeste + 1;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (suroeste >= 0 && listaGeneral[suroeste].Color != null) //que sea mayor al borde del tablero
            {
                while (suroeste >= 0 && suroeste < 64)
                {
                    if (turno)
                    {
                        if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[suroeste];
                            listaFichasCambiar.Add(ficha);
                            suroeste = suroeste + 9;
                        }
                        else if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[suroeste];
                            listaFichasCambiar.Add(ficha);
                            suroeste = suroeste + 9;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (sur >= 0 && listaGeneral[sur].Color != null) //que sea mayor al borde del tablero
            {
                while (sur >= 0 && sur < 64)
                {
                    if (turno)
                    {
                        if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[sur];
                            listaFichasCambiar.Add(ficha);
                            sur = sur + 8;
                        }
                        else if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[sur];
                            listaFichasCambiar.Add(ficha);
                            sur = sur + 8;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (sureste >= 0 && listaGeneral[sureste].Color != null) //que sea mayor al borde del tablero
            {
                while (sureste >= 0 && sureste < 64)
                {
                    if (turno)
                    {
                        if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[sureste];
                            listaFichasCambiar.Add(ficha);
                            sureste = sureste + 7;
                        }
                        else if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[sureste];
                            listaFichasCambiar.Add(ficha);
                            sureste = sureste + 7;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (este >= 0 && listaGeneral[este].Color != null) //que sea mayor al borde del tablero
            {
                while (este >= 0 && este < 64)
                {
                    if (turno)
                    {
                        if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[este];
                            listaFichasCambiar.Add(ficha);
                            este = este - 1;
                        }
                        else if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[este];
                            listaFichasCambiar.Add(ficha);
                            este = este - 1;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            if (noreste >= 0 && listaGeneral[noreste].Color != null) //que sea mayor al borde del tablero
            {
                while (noreste >= 0 && noreste < 64)
                {
                    if (turno)
                    {
                        if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[noreste];
                            listaFichasCambiar.Add(ficha);
                            noreste = noreste - 9;
                        }
                        else if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (coloresJ1.Contains(listaGeneral[norte].Color))
                        {
                            Pieza ficha = listaGeneral[noreste];
                            listaFichasCambiar.Add(ficha);
                            noreste = noreste - 9;
                        }
                        else if (coloresJ2.Contains(listaGeneral[norte].Color))
                        {
                            encierra = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (encierra && listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaGeneral[listaFichasCambiar[i].ID].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();
            encierra = false;

            #endregion
            var random1 = new Random();
            var random2 = new Random();
            int randomJ1 = random1.Next(coloresJ1.Count);
            int randomJ2 = random2.Next(coloresJ2.Count);
            if (listaGeneral[indice].Color is null && turno)
            {
                listaGeneral[indice].Color = coloresJ1[randomJ1];
                ViewBag.colorJ1 = listaGeneral[indice].Color;
                turno = false;
            }
            else if (listaGeneral[indice].Color is null && turno == false)
            {
                listaGeneral[indice].Color = coloresJ2[randomJ2];
                ViewBag.colorJ2 = listaGeneral[indice].Color;
                turno = true;
            }

            for (int i = 0; i < total; i++)
            {
                if (coloresJ1.Contains(listaGeneral[i].Color))
                {
                    contadorNegras++;
                }
                else if (coloresJ2.Contains(listaGeneral[i].Color))
                {
                    contadorBlancas++;
                }
            }
            ViewBag.contadorNegras = contadorNegras;
            ViewBag.contadorBlancas = contadorBlancas;

            if (contadorNegras + contadorBlancas == total)
            {
                if (modoX == "Reto Normal")
                {
                    if (contadorNegras < contadorBlancas)
                    {
                        ViewBag.Ganador = "El ganador es el Blanco";
                    }
                    else
                    {
                        ViewBag.Ganador = "El ganador es el Negro";
                    }
                }
                else
                {
                    if (contadorNegras > contadorBlancas)
                    {
                        ViewBag.Ganador = "El ganador es el Blanco";
                    }
                    else
                    {
                        ViewBag.Ganador = "El ganador es el Negro";
                    }
                }
            }
            Cronometro();
            return View("OthelloXtream", listaGeneral);
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