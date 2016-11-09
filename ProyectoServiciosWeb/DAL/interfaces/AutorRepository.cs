using ProyectosServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosServiciosWeb.DAL
{
    interface AutorRepository
    {
        IList<Autor> getAll();

        void delete(int id);

        Autor create(Autor autor);

        Autor update(Autor autor);

        Autor getById(int id);
    }
}
