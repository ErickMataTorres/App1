using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagEmpleados : ContentPage
	{
        private List<clases.EmpleadoLista> empleados;
		public PagEmpleados ()
		{
			InitializeComponent ();
            indicador.BindingContext = this;
            txtFiltro.SearchButtonPressed += TxtFiltro_SearchButtonPressed;
            btnNuevo.Clicked += BtnNuevo_Clicked;
            lista.ItemTapped += Lista_ItemTapped;
		}

        private async void BtnNuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagEmpleado(null));
        }

        private async void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var emp = (clases.EmpleadoLista)e.Item;
            var resp = await DisplayAlert("Confirme", "¿ ver los datos del empleado " + emp.Nombre + " ?", "Si","No");
            if (resp) {
                IsBusy = true;
                var empleado = await clases.Servicio.cargarEmpleado(emp.Id, PagLogin.empresa.Id);
                IsBusy = false;
                await Navigation.PushAsync(new PagEmpleado(empleado));
            }
        }

        private async void TxtFiltro_SearchButtonPressed(object sender, EventArgs e)
        {
            IsBusy = true;
            empleados = await clases.Servicio.listaEmpleados(PagLogin.empresa.Id, txtFiltro.Text);
            IsBusy = false;
            lista.ItemsSource = empleados;
        }
    }
}