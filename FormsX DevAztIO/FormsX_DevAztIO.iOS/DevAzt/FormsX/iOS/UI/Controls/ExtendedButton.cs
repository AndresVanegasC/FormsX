using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button),
                          typeof(DevAzt.FormsX.iOS.UI.Controls.ExtendedButton))]
namespace DevAzt.FormsX.iOS.UI.Controls
{
    public class ExtendedButton : ButtonRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var fontfamily = DevAzt.FormsX.UI.Controls.ExtendedViewControl.FontSource;
            if (!string.IsNullOrEmpty(fontfamily))
            {
                if (e.NewElement != null)
                {
                    e.NewElement.FontFamily = fontfamily;
                }
            }
        }

    }
}
