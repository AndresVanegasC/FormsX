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
using Android.Graphics;

[assembly: ExportRenderer(typeof(Label), typeof(DevAzt.FormsX.Droid.Controls.ExtendedLabel))]
namespace DevAzt.FormsX.Droid.Controls
{
    public class ExtendedLabel : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var fontfamily = DevAzt.FormsX.Controls.ExtendedLabel.FontSource;
            if (!string.IsNullOrEmpty(fontfamily))
            {
                e.NewElement.FontFamily = $"{fontfamily}.ttf#{fontfamily}";
            }
        }
    }
}