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
	public partial class PagEmpleado : ContentPage
	{
        private clases.Empleado empleado;
        
		public PagEmpleado (clases.Empleado e)
		{
			InitializeComponent ();
            btnOk.Clicked += BtnOk_Clicked;
            indicador.BindingContext = this;
            empleado = e;
            if(empleado != null)
                mostrarDatos();
		}

        private async void BtnOk_Clicked(object sender, EventArgs e)
        {
            grabarDatos();
            IsBusy = true;
            var res = await clases.Servicio.grabaEmpleado(empleado);
            IsBusy = false;
            if (res.StartsWith("Error"))
                await DisplayAlert("Error", res, "OK");
            else {
                await DisplayAlert("Atencion", "Se guardo el empleado con el ID-" + res, "OK");
                await Navigation.PopAsync();
            }
        }
        private void grabarDatos() {
            if (empleado == null)
            {
                empleado = new clases.Empleado();
                empleado.Empresa = PagLogin.empresa.Id;
            }
            empleado.ApePat = txtApePat.Text;
            empleado.ApeMat = txtApeMat.Text;
            empleado.Nombre = txtNom.Text;
            empleado.Puesto = txtPuesto.Text;
            empleado.Sueldo = decimal.Parse(txtSueldo.Text);
            empleado.FechaIngreso = txtFechaIng.Date;
        }
        private void mostrarDatos() {
            txtApePat.Text = empleado.ApePat;
            txtApeMat.Text = empleado.ApeMat;
            txtNom.Text = empleado.Nombre;
            txtPuesto.Text = empleado.Puesto;
            txtSueldo.Text = empleado.Sueldo.ToString();
            txtFechaIng.Date = empleado.FechaIngreso;
        }
    }
}