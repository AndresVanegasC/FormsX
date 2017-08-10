using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevAzt.FormsX.UI.ExtendedControls
{
    public static class TappedExtension
    {

        public static void Click<T>(this View element, Action<T> action, T t = default(T))
        {
            if (element != null)
            {
                element.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command<T>(action), CommandParameter = t });
            }
        }

    }
}
