using System;
using System.Collections.Generic;
using System.Text;

namespace JRA_Lab1.Model
{
    public class PersonModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Descripcion { get; set; }
        public string NombreCompleto { get => Nombre +" "+Apellido;  }

        public PersonModel(){}


    }
}
