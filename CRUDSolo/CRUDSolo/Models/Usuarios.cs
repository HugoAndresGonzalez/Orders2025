using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDSolo.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Estado { get; set; }
    }
}