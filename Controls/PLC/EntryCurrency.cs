using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PSM.Function
{

    public class EntryCurrency : View
    {
        public string Text { get; set; }

        public event EventHandler<EntryCurrencyTextChanged> EntryCurrencyTextChanged;

        public void OnEntryCurrencyTextChanged(string text, string currency)
        {
            if (EntryCurrencyTextChanged != null)
            {
                EntryCurrencyTextChanged.Invoke(this, new EntryCurrencyTextChanged
                {
                    Text = text,
                    Currency = currency
                });
            }
        }
    }

    public class EntryCurrencyTextChanged
    {
        public string Currency { get; set; }
        public string Text { get; set; }
    }

    public static class MoneyHelper
    {

        private static string _current_text = "";

        public static string TextToMoney(this string text)
        {
            if (!text.Equals(_current_text))
            {
                Regex reg = new Regex("[$.,]");
                string cleanString = reg.Replace(text, "");
                double parsed = 0;
                bool wasparse = double.TryParse(cleanString, out parsed);
                if (wasparse)
                {
                    var price = parsed / 100;
                    var formatted = price.ToString("C", new CultureInfo("en-US"));
                    _current_text = formatted;
                    return formatted;
                }
            }
            return "";
        }

        public static string MoneyToText(this string text)
        {
            double value = 0;
            var price = text.Replace('$', ' ').Trim();
            if (double.TryParse(price, out value))
            {
                price = string.Format(CultureInfo.CurrentCulture, "{0:F2}", value);
            }
            else
            {
                price = string.Empty;
            }
            return price;
        }

    }
}
