using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Othello.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Usuario> Users { get; set; }
    }
}