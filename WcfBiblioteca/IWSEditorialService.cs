using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWSEditorialService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWSEditorialService {
        [OperationContract]
        WSEditorial getEditorialById(int idEditorial);

        [OperationContract]
        List<WSEditorial> getAll();

        [OperationContract]
        void delete(int id);

        [OperationContract]
        string create(WSEditorial editorial);

        [OperationContract]
        string update(WSEditorial editorial);
    }

    [DataContract]
    public class WSEditorial {
        int codigo = -1;
        string nombre = "";
        string errorMessage = "";

        [DataMember]
        public int Codigo {
            get {
                return codigo;
            }
            set {
                codigo = value;
            }
        }

        [DataMember]
        public string Nombre {
            get {
                return nombre;
            }
            set {
                nombre = value;
            }
        }
        [DataMember]
        public string ErrorMessage {
            get {
                return errorMessage;
            }
            set {
                errorMessage = value;
            }
        }

    }
}
