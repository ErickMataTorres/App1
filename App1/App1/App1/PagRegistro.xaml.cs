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
	public partial class PagRegistro : ContentPage
	{
        private List<clases.CatalogoSat> regimenes, periodicidades;
		public PagRegistro ()
		{
			InitializeComponent ();
            btnOk.Clicked += BtnOk_Clicked;
            cargarCatalogos();
		}

        private void BtnOk_Clicked(object sender, EventArgs e)
        {
            guardar();
        }
        private async void guardar() {
            clases.Empresa e;
            string res;
            if (txtPwd.Text == null || txtPwd.Text.Length < 5) {
                await DisplayAlert("Error", "Debe poner al menos 5 caracteres", "OK");
                return;
            }
            if (txtPwd.Text != txtPwdB.Text)
            {
                await DisplayAlert("Error", "contraseña incorrecta", "OK");
                return;
            }
            e = new clases.Empresa();
            e.Nombre = txtNom.Text;
            e.Rfc = txtRfc.Text;
            e.RegImss = txtRegImss.Text;
            e.Pwd = txtPwd.Text;
            e.Regimen = regimenes[pkrReg.SelectedIndex].Id;
            e.Periodicidad = periodicidades[pkrPer.SelectedIndex].Id;
            res = await clases.Servicio.registrar(e);
            if (res.StartsWith("Error"))
                await DisplayAlert("Error", res, "OK");
            else {
                await DisplayAlert("Atencion", "Se registro la empresa", "OK");
                await Navigation.PopAsync();
            }
        }
        private async void cargarCatalogos() {
            regimenes = await clases.Servicio.cargarRegimenes();
            periodicidades = await clases.Servicio.cargarPeriodicidades();
            pkrReg.ItemsSource = regimenes;
            pkrPer.ItemsSource = periodicidades;
        }
	}
}