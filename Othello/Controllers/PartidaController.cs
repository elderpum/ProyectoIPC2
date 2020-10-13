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
        Pieza pieza = new Pieza();
        bool turno = true; //Cuando sea verdadera, es el turno del negro. Cuando sea falsa, es el turno del blanco.
        static List<Pieza> listaGeneral = new List<Pieza>();
        // GET: Tablero
        public ActionResult Sala1()
        {
            for (int i = 0; i < 64; i++)
            {
                pieza.ID = 0;
                listaGeneral.Add(pieza);
            }
            
            return View(listaGeneral);
        }
        public ActionResult Redirect()
        {
            return Redirect("~/Partida/Sala1");
        }

        public ActionResult CambioFicha(string io)
        {
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
            if (norte >= 0) //que sea mayor al borde del tablero
            {
                while (norte < 64)
                {
                    if (listaGeneral[norte].Color == "black" && turno == false)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = norte;
                        listaFichasCambiar.Add(ficha);
                        norte = norte - 8;
                    }
                    else if (listaGeneral[norte].Color == "white" && turno)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = norte;
                        listaFichasCambiar.Add(ficha);
                        norte = norte - 8;
                    }
                    else
                    {
                        if (listaGeneral[norte] is null)
                        {
                            break;
                        }
                    }
                }
                if (listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();

            if (noroeste >= 0) //que sea mayor al borde del tablero
            {
                while (noroeste < 64)
                {
                    if (listaGeneral[noroeste].Color == "black" && turno == false)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = noroeste;
                        listaFichasCambiar.Add(ficha);
                        noroeste = noroeste - 7;
                    }
                    else if (listaGeneral[noroeste].Color == "white" && turno)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = noroeste;
                        listaFichasCambiar.Add(ficha);
                        noroeste = noroeste - 7;
                    }
                    else
                    {
                        if (listaGeneral[noroeste] is null)
                        {
                            break;
                        }
                    }
                }
                if (listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();

            if (oeste >= 0) //que sea mayor al borde del tablero
            {
                while (oeste < 64)
                {
                    if (listaGeneral[oeste].Color == "black" && turno == false)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = oeste;
                        listaFichasCambiar.Add(ficha);
                        oeste = oeste + 1;
                    }
                    else if (listaGeneral[oeste].Color == "white" && turno)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = noroeste;
                        listaFichasCambiar.Add(ficha);
                        oeste = oeste + 1;
                    }
                    else
                    {
                        if (listaGeneral[oeste] is null)
                        {
                            break;
                        }
                    }
                }
                if (listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();

            if (suroeste >= 0) //que sea mayor al borde del tablero
            {
                while (suroeste < 64)
                {
                    if (listaGeneral[suroeste].Color == "black" && turno == false)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = suroeste;
                        listaFichasCambiar.Add(ficha);
                        suroeste = suroeste + 9;
                    }
                    else if (listaGeneral[suroeste].Color == "white" && turno)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = suroeste;
                        listaFichasCambiar.Add(ficha);
                        suroeste = suroeste + 9;
                    }
                    else
                    {
                        if (listaGeneral[suroeste] is null)
                        {
                            break;
                        }
                    }
                }
                if (listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();

            if (sur >= 0) //que sea mayor al borde del tablero
            {
                while (sur < 64)
                {
                    if (listaGeneral[sur].Color == "black" && turno == false)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = sur;
                        listaFichasCambiar.Add(ficha);
                        sur = sur + 8;
                    }
                    else if (listaGeneral[sur].Color == "white" && turno)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = sur;
                        listaFichasCambiar.Add(ficha);
                        sur = sur + 8;
                    }
                    else
                    {
                        if (listaGeneral[sur] is null)
                        {
                            break;
                        }
                    }
                }
                if (listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();

            if (sureste >= 0) //que sea mayor al borde del tablero
            {
                while (sureste < 64)
                {
                    if (listaGeneral[sureste].Color == "black" && turno == false)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = sureste;
                        listaFichasCambiar.Add(ficha);
                        sureste = sureste + 7;
                    }
                    else if (listaGeneral[sureste].Color == "white" && turno)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = sureste;
                        listaFichasCambiar.Add(ficha);
                        sureste = suroeste + 7;
                    }
                    else
                    {
                        if (listaGeneral[sureste] is null)
                        {
                            break;
                        }
                    }
                }
                if (listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();

            if (este >= 0) //que sea mayor al borde del tablero
            {
                while (este < 64)
                {
                    if (listaGeneral[este].Color == "black" && turno == false)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = este;
                        listaFichasCambiar.Add(ficha);
                        este = este - 1;
                    }
                    else if (listaGeneral[este].Color == "white" && turno)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = este;
                        listaFichasCambiar.Add(ficha);
                        este = este - 1;
                    }
                    else
                    {
                        if (listaGeneral[este] is null)
                        {
                            break;
                        }
                    }
                }
                if (listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();

            if (noreste >= 0) //que sea mayor al borde del tablero
            {
                while (noreste < 64)
                {
                    if (listaGeneral[noreste].Color == "black" && turno == false)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = noreste;
                        listaFichasCambiar.Add(ficha);
                        noreste = noreste - 9;
                    }
                    else if (listaGeneral[noroeste].Color == "white" && turno)
                    {
                        Pieza ficha = new Pieza();
                        ficha.ID = noreste;
                        listaFichasCambiar.Add(ficha);
                        noreste = noreste - 9;
                    }
                    else
                    {
                        if (listaGeneral[noreste] is null)
                        {
                            break;
                        }
                    }
                }
                if (listaFichasCambiar.Count > 0)
                {
                    if (turno)
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "black";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listaFichasCambiar.Count; i++)
                        {
                            listaFichasCambiar[i].Color = "white";
                        }
                    }
                }
            }

            listaFichasCambiar.Clear();

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
            return View("Sala1", listaGeneral);
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