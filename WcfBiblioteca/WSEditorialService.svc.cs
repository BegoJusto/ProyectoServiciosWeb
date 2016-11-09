using ProyectosServiciosWeb.BBLL;
using ProyectosServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WSEditorialService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WSEditorialService.svc o WSEditorialService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WSEditorialService : IWSEditorialService {
        EditorialService eS = new EditorialServiceImp();

        public string create(WSEditorial editorial) {
            string resultado = "";
            if (eS.getById(editorial.Codigo) == null) {
                eS.create(parseWSEditorialToEditorial(editorial));
                resultado = "Editorial creado";
            } else {
                resultado = "No se ha podido crear la Editorial";
            }
            return resultado;
        }

        public void delete(int idEditorial) {
            Editorial editorial = eS.getById(idEditorial);
            if (editorial != null) {
                eS.delete(idEditorial);
            }
        }

        public List<WSEditorial> getAll() {
            IList<Editorial> listaEditoriales = eS.getAll();
            List<WSEditorial> listaWSEditoriales = new List<WSEditorial>();
            WSEditorial wsEditorial = new WSEditorial();
            foreach (var editorial in listaEditoriales) {
                editorial.CodEditorial = wsEditorial.Codigo;
                editorial.Nombre = wsEditorial.Nombre;
                listaWSEditoriales.Add(wsEditorial);
            }
            return listaWSEditoriales;
        }

        public WSEditorial getEditorialById(int idEditorial) {

            WSEditorial wsEditorial = new WSEditorial();
            Editorial editAux = eS.getById(idEditorial);
            if (editAux == null) {
                wsEditorial.ErrorMessage = "La Editorial no existe";
                throw new Exception();
            } else {
                wsEditorial.Nombre = editAux.Nombre;
            }
            return wsEditorial;
        }

        public string update(WSEditorial editorial) {
            string resultado = "";
            if (eS.getById(editorial.Codigo) != null) {
                eS.update(parseWSEditorialToEditorial(editorial));
                resultado = "La Editorial se ha actualizado correctamente";
            } else {
                resultado = "No se ha encontrado la Editorial";
            }
            return resultado;
        }

        private Editorial parseWSEditorialToEditorial(WSEditorial editorial) {
            Editorial aux = new Editorial();
            aux.Nombre = editorial.Nombre;
            return aux;
        }
    }
}
