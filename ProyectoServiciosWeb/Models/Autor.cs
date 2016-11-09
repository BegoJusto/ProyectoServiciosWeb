using System.ComponentModel.DataAnnotations;

namespace ProyectosServiciosWeb.Models {
    public class Autor
    {
       
        private int _codAutor;
        private string _nombre;
       
        private string _apellidos {get; set;}

        public Autor()
        {
            this._codAutor = -1;
            this._nombre = "";

        }
        public int CodAutor
        {
            get
            {
                return _codAutor;
            }

            set
            {
                _codAutor = value;
            }
        }

        //Con el DisplayName puedes poner un alias para en la vista ver este nombre con html.labelfor, aunque lo malo es que no se puede internacionalizar
       
        public string Nombre
        {
            get
            {
                return _nombre.Trim();
            }

            set
            {
                _nombre = value.Trim();
            }
        }
        public string Apellidos {
            get {
                return _apellidos.Trim();
            }

            set {
                _apellidos = value.Trim();
            }
        }


    }
}