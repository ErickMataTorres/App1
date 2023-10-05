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
	public partial class PagMenu : ContentPage
	{
		public PagMenu ()
		{
			InitializeComponent ();
            lblEmpresa.Text = PagLogin.empresa.Nombre;
            btnLogout.Clicked += BtnLogout_Clicked;
            btnEmpleados.Clicked += BtnEmpleados_Clicked;
            btnNomina.Clicked += BtnNomina_Clicked;
        }

        private async void BtnNomina_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagCaptura(1,1));
        }

        private void BtnEmpleados_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagEmpleados());
        }

        private async void BtnLogout_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayAlert("Confirme","¿ desea cerrar la sesion ?", "Si", "No");
            if (res) {
                App.Current.Properties.Remove("rfc");
                App.Current.Properties.Remove("pwd");
                App.Current.MainPage = new NavigationPage(new PagLogin());
                await App.Current.SavePropertiesAsync();
            }
        }
    }
}