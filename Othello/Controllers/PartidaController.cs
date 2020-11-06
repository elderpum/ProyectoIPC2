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
            for (int i = 0; i < total; i++)
            {
                Pieza pieza = new Pieza(i);
                listaGeneral.Add(pieza);
                listaGeneral[i].Color = null;
            }
            turno = true;
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

        public ActionResult CambioFichaXtream(string io)
        {
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
                if (contadorNegras > contadorBlancas)
                {
                    ViewBag.Ganador = "El ganador es el Blanco";
                }
                else
                {
                    ViewBag.Ganador = "El ganador es el Negro";
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