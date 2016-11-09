using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWSEjemplarService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWSEjemplarService {
        [OperationContract]
        WSEjemplar getEjemplarById(int idEjemplar);
        [OperationContract]
        List<WSEjemplar> getAll();
        [OperationContract]
        void delete(int id);
        [OperationContract]
        string create(WSEjemplar ejemplar);
        [OperationContract]
        string update(WSEjemplar ejemplar);


    }
    [DataContract]
    public class WSEjemplar {
        int codigo = -1;
        DateTime fPublicacion = new DateTime();
        int numPaginas = 0;
        string isbn = "";
        string errorMessage = "";
        // Editorial editorial;        

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
        public DateTime FPublicacion {
            get {
                return fPublicacion;
            }
            set {
                fPublicacion = value;
            }
        }
        [DataMember]
        public int NumPaginas {
            get {
                return numPaginas;
            }
            set {
                numPaginas = value;
            }
        }
        [DataMember]
        public string ISBN {
            get {
                return isbn;
            }
            set {
                isbn = value;
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
