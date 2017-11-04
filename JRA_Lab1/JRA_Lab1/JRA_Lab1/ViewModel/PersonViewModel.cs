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

        public ObservableCollection<PersonModel> lstPersonList
        {

            get
            {
                //Tarea
                return (ObservableCollection<PersonModel>)_lstPersonList.Where(f => f.Nombre == _Filtro).ToList().AsEnumerable();
            }

            set
            {
                _lstPersonList = value;
                OnPropertyChanged("lstPersonList");
            }
        }

        public string _NuevoIngreso;
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

        public string _Filtro;
        public string Filtro
        {
            get
            {
                return _Filtro;
            }
            set
            {
                _Filtro = value;
                OnPropertyChanged("Filtro");

            }
        }
        //interfaz de comandos
        public ICommand AgregarPersonaCommand { get; set; }

        public ICommand BuscarPersonaCommand { get; set; }
        #endregion

        private void AgregarPersona()
        {

            lstPersonList.Add(new PersonModel
            {
                Nombre = NuevoIngreso,
                Apellido = "Araya",
                Descripcion = "Descripcion"
            });
        }

        private void BuscarPersona()
        {
            
        }

        public PersonViewModel()
        {
            AgregarPersonaCommand = new Command(AgregarPersona);
            BuscarPersonaCommand = new Command(BuscarPersona);
        }

        

        #region Notified Interface
        //Un hilo que nos maneja entre las clases ciertos eventos(Handler)
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        #endregion

    }
}
