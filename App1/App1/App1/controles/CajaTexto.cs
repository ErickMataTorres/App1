using Xamarin.Forms;

namespace App1.controles
{
    public class CajaTexto : Entry
    {
        public bool ConBorde { get; set; }
        public bool Mayusculas { get; set; }

        public CajaTexto() {
            ConBorde = true;
            Mayusculas = true;
        }
    }
}
