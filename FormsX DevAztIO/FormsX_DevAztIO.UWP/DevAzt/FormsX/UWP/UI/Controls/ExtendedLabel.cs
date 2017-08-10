
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Label), 
                          typeof(DevAzt.FormsX.UWP.UI.Controls.ExtendedLabel))]
namespace DevAzt.FormsX.UWP.UI.Controls
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
                    e.NewElement.FontFamily = $"Assets/{fontfamily}.ttf#{fontfamily}";
                }
            }
        }

    }
}