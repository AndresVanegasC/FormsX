using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(DevAzt.FormsX.Droid.UI.Controls.ExtendedButton))]
namespace DevAzt.FormsX.Droid.UI.Controls
{
    public class ExtendedButton : ButtonRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            var fontfamily = DevAzt.FormsX.UI.Controls.ExtendedViewControl.FontSource;
            if (!string.IsNullOrEmpty(fontfamily))
            {
                if (e.NewElement != null)
                {
                    e.NewElement.FontFamily = $"{fontfamily}.ttf#{fontfamily}";
                }
            }
        }
        
    }
}