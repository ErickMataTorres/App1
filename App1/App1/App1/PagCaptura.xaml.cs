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
	public partial class PagCaptura : ContentPage
	{
        private List<clases.Captura> conceptos;
        private int empresa, empleado;
		public PagCaptura (int empre, int emple)
		{
			InitializeComponent ();
            empresa = empre;
            empleado = emple;
            indicador.BindingContext = this;
            cargarCaptura();
		}
        private void guardar() {
            crearLista();
        }
        private string crearLista() {
            var lista = new List<clases.GrabaCaptura>();
            foreach (var c in conceptos) {
                if (c.Importe > 0) {
                    lista.Add(new clases.GrabaCaptura() { Id = c.Id, Importe = c.Importe });
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(lista);
        }
        private async void cargarCaptura() {
            IsBusy = true;
            conceptos = await clases.Servicio.cargarCaptura(empresa, empleado);
            IsBusy = false;
            lista.ItemsSource = conceptos;
        }
	}
}