
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), 
                          typeof(DevAzt.FormsX.iOS.UI.Controls.ExtendedLabel))]
namespace DevAzt.FormsX.iOS.UI.Controls
{
    public class ExtendedLabel : LabelRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
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