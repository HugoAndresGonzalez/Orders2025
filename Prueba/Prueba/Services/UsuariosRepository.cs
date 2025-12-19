using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Services
{
    public class UsuariosRepository
    {
        public PruebaContext Context = new PruebaContext();

        public List<Usuarios> ConsultarTodos()
        {
            List<Usuarios> Listi = new List<Usuarios>();
            try
            {
                Listi = Context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Listi;
        }

        public Usuarios ObtenerDato(int Id)
        {
            Usuarios usu = new Usuarios();
            try
            {
                usu = Context.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo el usuario", ex);
            }
            return usu;
        }

        public String EditDatos(int Id, Usuarios model)
        {
            try
            {
                Usuarios Datos = ObtenerDato(Id);
                Context.Usuarios.Attach(Datos);
                Datos.Nombre = model.Nombre;
                Datos.Apellido = model.Apellido;
                Datos.Estado = model.Estado;
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return "";
        }

        public String CrearUsuario(Usuarios model)
        {
            try
            {
                Context.Usuarios.Add(model);
                Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return "";
        }

        public String EliminarUsuario(int id, Usuarios model)
        {
            try
            {
                Usuarios datos = ObtenerDato(id);
                Context.Usuarios.Remove(datos);
                Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return "";
        }
    }
}