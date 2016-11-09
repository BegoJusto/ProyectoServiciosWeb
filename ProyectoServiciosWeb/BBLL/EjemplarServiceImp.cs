using ProyectosServiciosWeb.BBLL.interfaces;
using ProyectosServiciosWeb.DAL;
using ProyectosServiciosWeb.Models;
using System.Collections.Generic;

namespace ProyectosServiciosWeb.BBLL {
    public class EjemplarServiceImp : EjemplarService
    {
        private EjemplarRepositoryImp eR;

        public EjemplarServiceImp()
        {
            eR = new EjemplarRepositoryImp();
        }
        public Ejemplar create(Ejemplar ejemplar)
        {
            return eR.create(ejemplar);
        }

        public void delete(int codigoEjemplar)
        {
            eR.delete(codigoEjemplar);
        }

        public IList<Ejemplar> getAll()
        {
            return eR.getAll();
        }

        public IList<Ejemplar> getByIdDeLibro(int codLibro) {
            return eR.getByIdDeLibro(codLibro);
        }

        public Ejemplar getEjemplarById(int codigoEjemplar)
        {
            return eR.getById(codigoEjemplar);
        }
         
        public Ejemplar update(Ejemplar ejemplar)
        {
            return eR.update(ejemplar);
        }
    }
}