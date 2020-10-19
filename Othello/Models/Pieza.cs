using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Othello.Models
{
    public class Pieza
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string ContadorJ1 { get; set; }
        public string ContadorJ2 { get; set; }

        public Pieza() 
        {
            this.Color = null;
        }
        public Pieza(int id) 
        {
            this.ID = id;
            this.Color = null;
        }
    }
}