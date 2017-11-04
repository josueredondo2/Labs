using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRA_Lab1.ViewModel;
using Xamarin.Forms;

namespace JRA_Lab1
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            //Crea la liga entre la vista con el viewmodel
            BindingContext = new PersonViewModel();
		}
	}
}
