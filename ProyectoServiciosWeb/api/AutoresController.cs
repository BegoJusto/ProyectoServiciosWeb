using ProyectosServiciosWeb.BBLL;
using ProyectosServiciosWeb.BBLL.interfaces;
using ProyectosServiciosWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoServiciosWeb.api {
    public class AutoresController : ApiController {
        private AutorService aS;
        public AutoresController() {
            aS = new AutorServiceImp();
        }

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage GetAll() {
            IList<Autor> autores = aS.getAll();
            var response = Request.CreateResponse<IList<Autor>>(System.Net.HttpStatusCode.OK, autores);
            return response;
        }

        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage GetById(int id) {

            Autor autor = aS.getByID(id);
            HttpResponseMessage response;
            if (autor != null) {
                response = Request.CreateResponse<Autor>(System.Net.HttpStatusCode.OK, autor);
            } else {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }

            return response;
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post(Autor autor) {
            aS.create(autor);
            return Request.CreateResponse(System.Net.HttpStatusCode.Created);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage Put(Autor autor) {
            aS.update(autor);
            return Request.CreateResponse<Autor>(System.Net.HttpStatusCode.OK, autor);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id) {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
    }
}