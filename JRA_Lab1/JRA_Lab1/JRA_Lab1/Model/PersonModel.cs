using System;
using System.Collections.Generic;
using System.Text;

namespace JRA_Lab1.Model
{
    public class PersonModel
    {
        /// <summary>
        /// Nombre de la persona
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Apellido de la persona
        /// </summary>
        public string Apellido { get; set; }
        /// <summary>
        /// Descripcion de la persona
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Nombre completo de la persona
        /// </summary>
        public string NombreCompleto { get => Nombre +" "+Apellido;
        }                   }
}
