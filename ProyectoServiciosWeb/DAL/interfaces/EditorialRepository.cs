﻿
using ProyectosServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosServiciosWeb.DAL
{
    interface EditorialRepository
    {
        IList<Editorial> getAll();

        void delete(int id);

        Editorial create(Editorial editorial);

        Editorial update(Editorial editorial);

        Editorial getById(int id);



    }
}
