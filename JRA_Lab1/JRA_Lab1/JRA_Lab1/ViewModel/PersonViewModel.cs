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
        private ObservableCollection<PersonModel> _lstPersonList = new ObservableCollection<PersonModel>();

        private ObservableCollection<PersonModel> _lstPersonListOriginal = new ObservableCollection<PersonModel>();

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

        private string _Descripcion;
        public string NuevoDescripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
                OnPropertyChanged("NuevoDescripcion");

            }
        }


        private string _Filtro;
        public string Filtro
        {
            get
            {
                return _Filtro;
            }
            set
            {
                _Filtro = value;

                if (_lstPersonListOriginal.Count > 0)
                {
                    if (!String.IsNullOrEmpty(_Filtro))
                        lstPersonList = new ObservableCollection<PersonModel>(_lstPersonListOriginal.Where(a => a.NombreCompleto.ToLower().Contains(_Filtro.ToLower())));
                    else
                        lstPersonList = _lstPersonListOriginal;
                }

                OnPropertyChanged("Filtro");

            }
        }

        private PersonModel _Persona;
        public PersonModel Persona
        {
            get
            {
                return _Persona;
            }
            set
            {
                _Persona = value;
                OnPropertyChanged("Persona");
            }
        }

        //interfaz de comandos
        public ICommand AgregarPersonaCommand { get; set; }
        public ICommand BorrarPersonaCommand { get; set; }
        #endregion

        #region Metodos

        private void AgregarPersona()
        {

            _lstPersonListOriginal.Add(new PersonModel
            {
                Nombre = NuevoIngreso,
                Apellido = NuevoApellido,
                Descripcion = NuevoDescripcion
            });

            lstPersonList = _lstPersonListOriginal;
            NuevoIngreso = string.Empty;
            NuevoApellido = string.Empty;
            NuevoDescripcion = string.Empty;
        }

        private void BorrarPersona()
        {
            if (Persona != null)
            {
                _lstPersonListOriginal.Remove(Persona);
                lstPersonList = _lstPersonListOriginal;
            }
        }
        #endregion

        #region Contructor
        public PersonViewModel()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
            BorrarPersonaCommand = new Command(BorrarPersona);

            _lstPersonListOriginal.Add(new PersonModel
            {
                Nombre = "Josue",
                Apellido = "Redondo",
                Descripcion = "Desarrollador"
            });

            _lstPersonListOriginal.Add(new PersonModel
            {
                Nombre = "Cristiano",
                Apellido = "Ronaldo",
                Descripcion = "Real Madrid"
            });

            _lstPersonListOriginal.Add(new PersonModel
            {
                Nombre = "Leonel",
                Apellido = "Messi",
                Descripcion = "Barcelona"
            });

            lstPersonList = _lstPersonListOriginal;
        }
        #endregion

        #region Notified Interface
        //Un hilo que nos maneja entre las clases ciertos eventos(Handler)
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        #endregion

    }
}
