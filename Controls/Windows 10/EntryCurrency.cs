using DevAzt.FormsX.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(DevAzt.FormsX.Controls.EntryCurrency),
                          typeof(Test.UWP.Controls.EntryCurrency))]
namespace Test.UWP.Controls
{
    public class EntryCurrency : ViewRenderer<View, TextBox>
    {
        TextBox Box { get; set; }
        DevAzt.FormsX.Controls.EntryCurrency Currency;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            Currency = Element as DevAzt.FormsX.Controls.EntryCurrency;
            if (Currency != null && e.OldElement == null)
            {
                Box = new TextBox();
                if (!string.IsNullOrEmpty(Currency.Text))
                {
                    Box.Text = Currency.Text;
                }
                Box.PlaceholderText = "$0.00";
                var inputscope = new InputScope();
                inputscope.Names.Add(new InputScopeName(InputScopeNameValue.Number));
                Box.InputScope = inputscope;
                Box.TextChanged += Box_TextChanged;
                SetNativeControl(Box);
            }
        }

        private async void Box_TextChanged(object sender, Windows.UI.Xaml.Controls.TextChangedEventArgs e)
        {
            Box.TextChanged -= Box_TextChanged;
            if (Box != null)
            {
                var text = Box.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    var formatted = text.TextToMoney();
                    var currency = formatted.MoneyToText();
                    Currency.OnEntryCurrencyTextChanged(formatted, currency);
                    Currency.Text = formatted;
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        Box.Text = formatted;
                        Box.SelectionStart = formatted.Length;
                    });
                }
            }
            Box.TextChanged += Box_TextChanged;
        }
    }
}
