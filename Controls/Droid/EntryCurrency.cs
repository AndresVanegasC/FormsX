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
using PSM.Function;

[assembly: ExportRenderer(typeof(PSM.Function.EntryCurrency),
                          typeof(PSM.Droid.Function.EntryCurrency))]
namespace PSM.Droid.Function
{
    public class EntryCurrency : ViewRenderer
    {

        EditText Box;
        PSM.Function.EntryCurrency Currency;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            Currency = Element as PSM.Function.EntryCurrency;
            if (Currency != null && e.OldElement == null)
            {
                Box = new EditText(Context);
                if (!string.IsNullOrEmpty(Currency.Text))
                {
                    Box.Text = Currency.Text;
                }
                Box.Hint = "$0.00";
                Box.InputType = InputTypes.ClassNumber;
                Box.TextChanged += Box_TextChanged;
                SetNativeControl(Box);
            }
        }

        private void Box_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            Box.TextChanged -= Box_TextChanged;
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
                    Box.SetSelection(formatted.Length);
                }
            }
            Box.TextChanged += Box_TextChanged;
        }
    }
}