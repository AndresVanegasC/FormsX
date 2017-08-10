
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
                var number = "";
                return "";
            }
        }
    }
}