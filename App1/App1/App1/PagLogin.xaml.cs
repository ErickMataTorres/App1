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
	public partial class PagLogin : ContentPage
	{
        public static clases.Empresa empresa;
		public PagLogin ()
		{
			InitializeComponent ();
            indicador.BindingContext = this;
            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegistro.Clicked += BtnRegistro_Clicked;
            if (App.Current.Properties.ContainsKey("rfc")) {
                txtRfc.Text = (string)App.Current.Properties["rfc"];
                txtPwd.Text = (string)App.Current.Properties["pwd"];
                loguear();
            }
        }

        private void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagRegistro());
        }

        private async void loguear() {
            IsBusy = true;
            empresa = await clases.Servicio.loguear(txtRfc.Text, txtPwd.Text);
            IsBusy = false;
            if (empresa.Id == 0) {
                await DisplayAlert("Error", "Datos incorrectos", "OK");
                return;
            }
            App.Current.Properties["rfc"] = txtRfc.Text;
            App.Current.Properties["pwd"] = txtPwd.Text;
            await App.Current.SavePropertiesAsync();
            App.Current.MainPage = new NavigationPage(new PagMenu());

        }
        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            loguear();
        }
    }
}