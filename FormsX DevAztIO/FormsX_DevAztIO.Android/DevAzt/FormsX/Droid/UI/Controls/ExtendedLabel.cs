using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(DevAzt.FormsX.Droid.UI.ExtendedControls.ExtendedLabel))]
namespace DevAzt.FormsX.Droid.UI.ExtendedControls
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
                    e.NewElement.FontFamily = $"{fontfamily}.ttf#{fontfamily}";
                }
            }
        }
    }
}