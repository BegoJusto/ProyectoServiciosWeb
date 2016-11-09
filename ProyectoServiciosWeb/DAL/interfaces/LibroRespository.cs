﻿
using ProyectosServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectosServiciosWeb.DAL
{
    public interface LibroRespository
    {
        IList<Libro> getAll();

        Libro getById(int id);

        Libro create(Libro libro);

        void delete(int id);

        Libro update(Libro libro);
    }
}