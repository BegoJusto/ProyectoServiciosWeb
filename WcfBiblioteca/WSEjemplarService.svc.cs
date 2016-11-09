using ProyectosServiciosWeb.BBLL;
using ProyectosServiciosWeb.BBLL.interfaces;
using ProyectosServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WSEjemplarService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WSEjemplarService.svc o WSEjemplarService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WSEjemplarService : IWSEjemplarService {
        EjemplarService aS = new EjemplarServiceImp();

        public void delete(int idEjemplar) {
            Ejemplar ejemplar = aS.getEjemplarById(idEjemplar);
            if (ejemplar != null) {

                aS.delete(idEjemplar);
            }
        }

        public List<WSEjemplar> getAll() {
            IList<Ejemplar> listaEjemplares = aS.getAll();
            List<WSEjemplar> listaWSEjemplares = new List<WSEjemplar>();
            WSEjemplar wsEjemplar = new WSEjemplar();
            foreach (var ejemplar in listaEjemplares) {
                ejemplar.CodEjemplar = wsEjemplar.Codigo;
                ejemplar.ISBN = wsEjemplar.ISBN;
                ejemplar.NumPaginas = wsEjemplar.NumPaginas;
                listaWSEjemplares.Add(wsEjemplar);
            }
            return listaWSEjemplares;
        }



        public WSEjemplar getEjemplarById(int idEjemplar) {

            WSEjemplar wsEjemplar = null;
            Ejemplar ejemAux = aS.getEjemplarById(idEjemplar);
            wsEjemplar = new WSEjemplar();
            if (ejemAux == null) {
                wsEjemplar.ErrorMessage = "El Ejemplar no existe";
                throw new Exception();
            } else {
                wsEjemplar.NumPaginas = ejemAux.NumPaginas;
                wsEjemplar.ISBN = ejemAux.ISBN;
                wsEjemplar.FPublicacion = ejemAux.FPublicacion;
            }
            return wsEjemplar;
        }

        public string create(WSEjemplar ejemplar) {
            string resultado = "";
            if (aS.getEjemplarById(ejemplar.Codigo) == null) {

                aS.create(parseWSEjemplarToEjemplar(ejemplar));
                resultado = "Ejemplar Creado";
            } else {
                resultado = "No se ha podido crear el ejemplar";
            }

            return resultado;
        }

        private static Ejemplar parseWSEjemplarToEjemplar(WSEjemplar ejemplar) {
            Ejemplar aux = new Ejemplar();
            aux.NumPaginas = ejemplar.NumPaginas;
            aux.ISBN = ejemplar.ISBN;
            aux.FPublicacion = ejemplar.FPublicacion;
            return aux;
        }

        public string update(WSEjemplar ejemplar) {
            string resultado = "";
            if (aS.getEjemplarById(ejemplar.Codigo) != null) {
                aS.update(parseWSEjemplarToEjemplar(ejemplar));
                resultado = "El ejemplar se ha actualizado";
            } else {
                resultado = "No se ha encontradro libro";
            }
            return resultado;
        }
    }
}
