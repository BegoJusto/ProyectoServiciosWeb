using ProyectosServiciosWeb.Models;
using System.Collections.Generic;

namespace ProyectosServiciosWeb.BBLL.interfaces {
    public interface AutorService
    {
        Autor getByID(int codigoAutor);
        Autor create(Autor autor);
        Autor update(Autor autor);
        void delete(int codigoAutor);
        IList<Autor> getAll();
    }
}
