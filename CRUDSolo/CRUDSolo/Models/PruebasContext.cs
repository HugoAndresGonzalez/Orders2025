using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUDSolo.Models
{
    public class PruebasContext : DbContext
    {
        public PruebasContext() : base("Conexion")
        {
        }

        public virtual DbSet<Usuarios> Productos { get; set; }
    }
}