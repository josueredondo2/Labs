using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Linq;
using JRA_Lab1.Model;
using Xamarin.Forms;

namespace JRA_Lab1.ViewModel
{
    class PersonViewModel : INotifyPropertyChanged
    {
        #region Instances
        /// <summary>
        /// Lista base de personas
        /// </summary>
        private List<PersonModel> lstPersonListOriginal = new List<PersonModel>();
        /// <summary>
        /// Lista de personas
        /// </summary>
        private ObservableCollection<PersonModel> _lstPersonList = new ObservableCollection<PersonModel>();
        public ObservableCollection<PersonModel> lstPersonList
        {

            get
            {
                   
                return _lstPersonList;
            }

            set
            {
                _lstPersonList = value;
                OnPropertyChanged("lstPersonList");
            }
        }
        /// <summary>
        /// Nombre de persona
        /// </summary>
        private string _NuevoIngreso;
        public string NuevoIngreso
        {
            get
            {
                
                return _NuevoIngreso;
            }
            set
            {
                _NuevoIngreso = value;
                OnPropertyChanged("NuevoIngreso");

            }
        }
        /// <summary>
        /// Apellido de persona
        /// </summary>
        private string _NuevoApellido;
        public string NuevoApellido
        {
            get
            {

                return _NuevoApellido;
            }
            set
            {
                _NuevoApellido = value;
                OnPropertyChanged("NuevoApellido");

            }
        }
        /// <summary>
        /// Descripcion de persona
        /// </summary>
        private string _NuevoDescripcion;
        public string NuevoDescripcion
        {
            get
            {
                return _NuevoDescripcion;
            }
            set
            {
                _NuevoDescripcion = value;
                OnPropertyChanged("NuevoDescripcion");

            }
        }
        /////////// <summary>
        /////////// Filtro de busqueda
        /////////// </summary>
        ////////private string _Filtro;
        ////////public string Filtro
        ////////{
        ////////    get
        ////////    {
        ////////        return _Filtro;
        ////////    }
        ////////    set
        ////////    {
        ////////        _Filtro = value;

        ////////        if (_lstPersonListOriginal.Count > 0)
        ////////        {
        ////////            if (!String.IsNullOrEmpty(_Filtro))
        ////////                lstPersonList = new ObservableCollection<PersonModel>(_lstPersonListOriginal.Where(a => a.NombreCompleto.ToLower().Contains(_Filtro.ToLower())));
        ////////            else
        ////////                lstPersonList = _lstPersonListOriginal;
        ////////        }

        ////////        OnPropertyChanged("Filtro");

        ////////    }
        ////////}

        /// <summary>
        /// Filtro de busqueda
        /// </summary>
        private string _TextoBuscar;
        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }
            set
            {
                //                _TextoBuscar = value;

                //                if (lstPersonListOriginal.Count > 0)
                //                {
                //                    if (!String.IsNullOrEmpty(_TextoBuscar))
                //                        lstPersonList = lstPersonListOriginal.Where(a => a.NombreCompleto.ToLower().Contains(_TextoBuscar.ToLower())).ToList<PersonModel>;
                //1                    else
                //                        lstPersonList = lstPersonListOriginal;
                //                }
                _TextoBuscar = value;
                FiltrarPersona(_TextoBuscar);
                OnPropertyChanged("Filtro");

            }
        }


        ///////// <summary>
        ///////// Objeto persona para utilizar en la clase
        ///////// </summary>
        //////private PersonModel _Persona;
        //////public PersonModel Persona
        //////{
        //////    get
        //////    {
        //////        return _Persona;
        //////    }
        //////    set
        //////    {
        //////        _Persona = value;
        //////        OnPropertyChanged("Persona");
        //////    }
        //////}
        /// <summary>
        /// Interfaz de Icomandos
        /// </summary>
        public ICommand AgregarPersonaCommand { get; set; }
        public ICommand BorrarPersonaCommand { get; set; }

        #endregion

        #region Metodos
        /// <summary>
        /// Agrega una persona a la lista de personas
        /// </summary>
        private void AgregarPersona()
        {
            //Añade una persona a la lista
            lstPersonListOriginal.Add(new PersonModel
            {
                Nombre = NuevoIngreso,
                Apellido = NuevoApellido,
                Descripcion = NuevoDescripcion
            });
            //Define la lista a mostrar
            lstPersonList = new ObservableCollection<PersonModel>(lstPersonListOriginal);
            //Libera las variables
            LimpiarVariables();
        }
        /// <summary>
        /// Limpia las variables de la clase
        /// </summary>
        private void LimpiarVariables()
        {
            NuevoIngreso = string.Empty;
            NuevoApellido = string.Empty;
            NuevoDescripcion = string.Empty;
        }
        /// <summary>
        /// Elimina una persona de la lista
        /// </summary>
        private void BorrarPersona(int id)
        {
            lstPersonList.Clear();
            lstPersonListOriginal.RemoveAll(x => x.Id == id);
            lstPersonListOriginal.ToList().ForEach(x => lstPersonList.Add(x));
        }

        private void FiltrarPersona(string textoBuscar)
        {
            lstPersonList.Clear();
            lstPersonListOriginal.Where(x => x.Nombre.ToLower().Contains(textoBuscar.ToLower())).ToList().ForEach(x => lstPersonList.Add(x));

        }
        #endregion

        #region Contructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public PersonViewModel()
        {
            InitClass();
            InitCommands();
        }
        /// <summary>
        /// Inicializa los comandos
        /// </summary>
        private void InitCommands()
        {
            //Inicializa los comandos
            AgregarPersonaCommand = new Command(AgregarPersona);
            BorrarPersonaCommand = new Command<int>(BorrarPersona);
        }
        /// <summary>
        /// Inicializa las variable de la clase
        /// </summary>
        private void InitClass()
        {
            //Define la lista a mostrar
            lstPersonList = PersonModel.ObtenerPersonas();
            lstPersonListOriginal = lstPersonList.ToList();
        }
        #endregion

        #region Notified Interface
        /// <summary>
        /// Un hilo que nos maneja entre las clases ciertos eventos(Handler)
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Metodo de notificacion
        /// </summary>
        /// <param name="PropertyName">Nombre de propiedad</param>
        protected void OnPropertyChanged(string PropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        #endregion

    }
}
