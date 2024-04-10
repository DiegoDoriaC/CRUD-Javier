using System;
using System.Linq;
using System.Web.Mvc;
using JavierCRUD.DAO;
using JavierCRUD.Models;
using JavierCRUD.Interfaces;
using Microsoft.Ajax.Utilities;

namespace JavierCRUD.Controllers
{
    public class UsuarioController : Controller
    {        
        DAOUsuario dao = new DAOUsuario();        

        public ActionResult Get()
        {
            return View(dao.Usuarios());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Usuario u = dao.Usuarios().Where(x => x.ID == id).FirstOrDefault();
            return View(u);
        }

        [HttpPost]
        public ActionResult Delete(Usuario u, string pais)
        {
            dao.EliminarUsuario(u);
            return RedirectToAction("Get");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Create(Usuario u)
        {
            dao.CrearUsuario(u);
            return RedirectToAction("Get");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Usuario usuario = dao.Usuarios().FirstOrDefault(x => x.ID == id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(int id, Usuario u)
        {
            Usuario prueba = u;
            if (prueba.Nombre.Trim() == null)
            {
                ViewBag.MENSAJE = "El campo Telefono esta vacio";
                return View();
            }
            try
            {
                dao.ActualizarUsuario(id, u);
            }
            catch (Exception ex) { ViewBag.MENSAJE = "El campo Telefono no puede ser duplicado"; };

            return View();
        }



    }
}