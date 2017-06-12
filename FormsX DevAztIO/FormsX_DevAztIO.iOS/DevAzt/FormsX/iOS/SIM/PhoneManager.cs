using Forms.DeviceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

[assembly: Dependency(typeof(DevAzt.FormsX.iOS.SIM.PhoneManager))]
namespace DevAzt.FormsX.iOS.SIM
{
    public class PhoneManager : IPhoneManager
    {
        public string LineNumber
        {
            get
            {
                // Implements IPhoneManager
                return "";
            }
        }
    }
}