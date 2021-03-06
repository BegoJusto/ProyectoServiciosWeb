﻿
using ProyectosServiciosWeb.BBLL;
using ProyectosServiciosWeb.BBLL.interfaces;
using ProyectosServiciosWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectosServiciosWeb.Controllers {
   
    public class LibroController : Controller
    {
        private LibroService ls;
        private AutorService As;
        public LibroController()
        {
            ls = new LibroServiceImp();
            As = new AutorServiceImp();
        }
        // GET: Libro
        public ActionResult Index()
        {
            ActionResult paginaRedirect;
            IList<Libro> libros = ls.getAll();
            if(libros.Count() > 0)
            {
                paginaRedirect = View("Index", libros);
            }else
            {
                ViewBag.ErrorMessage = "No hay libros en la BB.DD.";
                paginaRedirect = View("Index", libros);
            }

            return paginaRedirect;
        }
        //POST: Libro/save
        [HttpPost]
        public ActionResult save(Libro libro)
        {
            ActionResult resultado = null;
            if (ModelState.IsValid)
            {
                if (libro.CodLibro > 0)
                {
                   
                        ls.update(libro);
                        ViewBag.Message = "El libro se ha actualizado";                   
                }
                else
                {
                    ls.create(libro);
                    ViewBag.Message = "Libro creado con éxito";
                }
                resultado = RedirectToAction("Index");

            }
            else
            {
                resultado = View("Libro",libro);
            }
            return resultado;
        }
        //GET: Libro/createUpdate
        public ActionResult createUpdate(int codigo = -1)
        {
            ActionResult resultado = null;
            Libro libro =  ls.getById(codigo);
            //IList<Autor> autores = As.getAll();
            ViewBag.AutorList = As.getAll();
            if (libro!=null)
            {
               // libro = ls.getById(codLibro);
                ViewBag.Title = "Editar Libro";
                resultado = View("Libro", libro);
            }else
            {
                ViewBag.Title = "Libro Nuevo";
                libro = new Libro();
                resultado = View("Libro", libro);
            }
            return resultado;
        }
        //GET: Libro/Delete
        public ActionResult delete(int codigo)
        {
            if (ls.getById(codigo) != null)
            {
                ls.delete(codigo);
                ViewBag.Message = "El libro se ha borrado";
            }
            return RedirectToAction("Index");
           
        }
    }
}