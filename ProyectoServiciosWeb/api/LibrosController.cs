using ProyectosServiciosWeb.BBLL;
using ProyectosServiciosWeb.BBLL.interfaces;
using ProyectosServiciosWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoServiciosWeb.api
{
    public class LibrosController : ApiController
    {
        private EjemplarService eS;
        public LibrosController() {
            eS = new EjemplarServiceImp();
        }
        // GET api/<controller>
        public HttpResponseMessage GetAll() {
            IList<Libro> libros = eS.getAll();

            var response = Request.CreateResponse<IList<Libro>>(System.Net.HttpStatusCode.OK, libros);


            return response;
        }

        // GET api/<controller>/5
        public HttpResponseMessage GetById(int id) {
            IList<Ejemplar> ejemplares = eS.getByIdDeLibro(id);
            HttpResponseMessage response;
            if (ejemplares != null) {
                response = Request.CreateResponse<IList<Ejemplar>>(System.Net.HttpStatusCode.OK, ejemplares);
            } else {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }

            return response;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Ejemplar ejemplar) {
            eS.create(ejemplar);
            return Request.CreateResponse(System.Net.HttpStatusCode.Created);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(Ejemplar ejemplar) {
            eS.update(ejemplar);
            return Request.CreateResponse<Ejemplar>(System.Net.HttpStatusCode.OK, ejemplar);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id) {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
    }
}
