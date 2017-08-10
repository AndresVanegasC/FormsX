using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DevAzt.FormsX.ApplicationModel.Programming.SimpleAuth
{
    public class LoginModel
    {
        public Page Page { get; set; }
        public string AppName { get; set; }
        public string EntryOne { get; set; }
        public string EntryTwo { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Opacity { get; set; }
        public string AppIcon { get; set; }
        public string ButtonOne { get; set; }
        public string Message { get; set; }
        public string BackgroundImage { get; set; }
        public Dictionary<string, string> Values { get; set;}
        public string EntryOneValue { get; set; }
        public string EntryTwoValue { get; set; }

        public event EventHandler<Dictionary<string, string>> LoginClick;

        public void OnLoginClick(Dictionary<string, string> vars)
        {
            if (LoginClick != null)
            {
                LoginClick.Invoke(this, vars);
            }
        }
    }
}
