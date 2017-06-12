using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DevAzt.FormsX.ApplicationModel.Chat;
using DevAzt.FormsX.SIM;
using Android.Telephony;
using Xamarin.Forms;

[assembly: Dependency(typeof(DevAzt.FormsX.Droid.SIM.MovilNetwork))]
namespace DevAzt.FormsX.Droid.SIM
{
    public class MovilNetwork : IMovilNetwork
    {
        public bool SendMessage(ChatMessage chatmessage)
        {
            var manager = SmsManager.Default;
            manager.SendTextMessage(chatmessage.From, null, chatmessage.Body, null, null);
            return true;
        }
    }
}