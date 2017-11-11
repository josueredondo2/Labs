using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JRA_Lab1.Model
{
    public class PersonModel
    {
        public int Id { get; set; }
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
        public string NombreCompleto { get => Nombre +" "+Apellido;}

        public static ObservableCollection<PersonModel> ObtenerPersonas()
        {
            ObservableCollection<PersonModel> lst = new ObservableCollection<PersonModel>();
            //Carga las personas de prueba
            lst.Add(new PersonModel
            {
                Id = 1,
                Nombre = "Keylor",
                Apellido = "Navas",
                Descripcion = "Real Madrid"
            });

            lst.Add(new PersonModel
            {
                Id = 2,
                Nombre = "Cristiano",
                Apellido = "Ronaldo",
                Descripcion = "Real Madrid"
            });

            lst.Add(new PersonModel
            {
                Id = 3,
                Nombre = "Leonel",
                Apellido = "Messi",
                Descripcion = "Barcelona"
            });
            lst.Add(new PersonModel
            {
                Id = 4,
                Nombre = "Manuel",
                Apellido = "Neuer",
                Descripcion = "Bayern"
            });

            lst.Add(new PersonModel
            {
                Id = 5,
                Nombre = "Eden",
                Apellido = "Hazzard",
                Descripcion = "Barcelona"
            });


            return lst;
        }

    }
}
