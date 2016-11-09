using ProyectosServiciosWeb.BBLL.interfaces;
using ProyectosServiciosWeb.DAL;
using ProyectosServiciosWeb.Models;
using System.Collections.Generic;

namespace ProyectosServiciosWeb.BBLL {
    public class LibroServiceImp : LibroService
    {
        private LibroRespository lr;

        public LibroServiceImp()
        {
            lr = new LibroRepositoryImp();
        }
        public Libro create(Libro libro)
        {
            return lr.create(libro);
        }

        public void delete(int codigoLibro)
        {
            lr.delete(codigoLibro);
        }

        public IList<Libro> getAll()
        {
            return lr.getAll();
        }

        public Libro getById(int codigoLibro)
        {
            return lr.getById(codigoLibro);
        }

        public Libro update(Libro libro)
        {
            return lr.update(libro);
        }
    }
}