using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Prueba.Models
{
    public class PruebaContext : DbContext
    {
        public PruebaContext() : base("Conexion")
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}