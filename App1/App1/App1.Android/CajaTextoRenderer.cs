using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(App1.controles.CajaTexto), typeof(App1.Droid.CajaTextoRenderer))]
namespace App1.Droid
{
    class CajaTextoRenderer : EntryRenderer
    {
        public CajaTextoRenderer(Context c) : base(c) {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Element != null)
            {
                var caja = Element as controles.CajaTexto;
                if(caja.ConBorde)
                    Control.SetBackgroundResource(Resource.Layout.Borde);
                if (caja.Mayusculas)
                    Control.SetFilters(new Android.Text.IInputFilter[] { new InputFilterAllCaps() });
            }
        }
    }
}