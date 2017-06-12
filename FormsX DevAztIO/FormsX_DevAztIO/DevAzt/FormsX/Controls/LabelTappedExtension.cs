using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevAzt.FormsX.Controls
{
    public static class LabelTappedExtension
    {

        public static void Click(this Label element, Action<Label> action)
        {
            if (element != null)
            {
                element.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command<Label>(action) });
            }
        }

    }
}
