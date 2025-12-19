using Prueba.Models;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Controllers
{
    public class UsuariosController : Controller
    {
        public UsuariosRepository Rep = new UsuariosRepository();

        // GET: Usuarios
        public ActionResult Index()
        {
            List<Usuarios> Datos = new List<Usuarios>();
            try
            {
                Datos = Rep.ConsultarTodos();
            }
            catch (Exception ex)
            {
            }
            return View(Datos);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            Usuarios Result = Rep.ObtenerDato(id);
            return View(Result);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            Usuarios usuarios = new Usuarios();
            return View(usuarios);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuarios model)
        {
            try
            {
                // TODO: Add insert logic here
                Rep.CrearUsuario(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                {
                    return View();
                }
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuarios Datos = Rep.ObtenerDato(id);
            return View(Datos);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuarios model)
        {
            try
            {
                // TODO: Add update logic here
                var Datos = Rep.EditDatos(id, model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usuarios Datos = Rep.ObtenerDato(id);
            return View(Datos);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuarios model)
        {
            try
            {
                // TODO: Add delete logic here
                Rep.EliminarUsuario(id, model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}