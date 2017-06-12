
using Android.Content;
using Android.Telephony;
using Xamarin.Forms;

using DevAzt.FormsX.SIM;

[assembly: Dependency(typeof(DevAzt.FormsX.Droid.SIM.PhoneManager))]
namespace DevAzt.FormsX.Droid.SIM
{
    public class PhoneManager : IPhoneManager
    {
        public string LineNumber {
            get
            {
                TelephonyManager tMgr = (TelephonyManager)Android.App.Application.Context.GetSystemService(Context.TelephonyService);
                return tMgr.Line1Number;
            }
        }
    }
}