
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), 
                          typeof(DevAzt.FormsX.iOS.Controls.ExtendedLabel))]
namespace DevAzt.FormsX.iOS.Controls
{
    public class ExtendedLabel : LabelRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var fontfamily = DevAzt.FormsX.Controls.ExtendedLabel.FontSource;
            if (!string.IsNullOrEmpty(fontfamily))
            {
                e.NewElement.FontFamily = fontfamily;
            }
        }

    }
}