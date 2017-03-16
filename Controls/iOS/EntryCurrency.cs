
using Xamarin.Forms;
using PSM.Function;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(PSM.Function.EntryCurrency),
                          typeof(PSM.Droid.Function.EntryCurrency))]
namespace PSM.Droid.Function
{
    public class EntryCurrency : ViewRenderer
    {

        UITextField Box;
        PSM.Function.EntryCurrency Currency;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            Currency = Element as PSM.Function.EntryCurrency;
            if (Currency != null && e.OldElement == null)
            {
                Box = new UITextField();
                if (!string.IsNullOrEmpty(Currency.Text))
                {
                    Box.Text = Currency.Text;
                }
                Box.Placeholder = "$0.00";
                Box.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
                Box.ValueChanged += Box_ValueChanged;
                SetNativeControl(Box);
            }
        }

        private void Box_ValueChanged(object sender, System.EventArgs e)
        {
            Box.ValueChanged -= Box_ValueChanged;
            if (Box != null)
            {
                var text = Box.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    var formatted = text.TextToMoney();
                    var currency = formatted.MoneyToText();
                    Currency.Text = formatted;
                    Currency.OnEntryCurrencyTextChanged(formatted, currency);
                    Box.Text = formatted;
                    //selection
                }
            }
            Box.ValueChanged += Box_ValueChanged;
        }
    }
}