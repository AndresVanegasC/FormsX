
using Xamarin.Forms;
using DevAzt.FormsX.Controls;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(DevAzt.FormsX.Controls.EntryCurrency),
                          typeof(Test.iOS.Controls.EntryCurrency))]
namespace Test.iOS.Controls
{
    public class EntryCurrency : ViewRenderer
    {

        UITextField Box;
        DevAzt.FormsX.Controls.EntryCurrency Currency;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            Currency = Element as DevAzt.FormsX.Controls.EntryCurrency;
            if (Currency != null && e.OldElement == null)
            {
				Box = new UITextField();
				Box.Layer.BorderColor = UIColor.LightGray.CGColor;
				Box.Layer.BorderWidth = 1f;
                if (!string.IsNullOrEmpty(Currency.Text))
                {
                    Box.Text = Currency.Text;
                }
                Box.Placeholder = "$0.00";
				Box.KeyboardType = UIKeyboardType.NumberPad;
				Box.EditingChanged += Box_ValueChanged;
                SetNativeControl(Box);
            }
        }

        private void Box_ValueChanged(object sender, System.EventArgs e)
        {
            Box.EditingChanged -= Box_ValueChanged;
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
            Box.EditingChanged += Box_ValueChanged;
        }
    }
}