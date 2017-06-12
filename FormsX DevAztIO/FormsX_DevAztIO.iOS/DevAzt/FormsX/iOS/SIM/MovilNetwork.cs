
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using DevAzt.FormsX.ApplicationModel.Chat;
using DevAzt.FormsX.SIM;
using MessageUI;
using UIKit;

[assembly: Dependency(typeof(DevAzt.FormsX.iOS.SIM.MovilNetwork))]
namespace DevAzt.FormsX.iOS.SIM
{
    public class MovilNetwork : IMovilNetwork
    {
        public bool SendMessage(ChatMessage chatmessage)
        {
            bool sendmessage = false;
            if (MFMessageComposeViewController.CanSendText)
            {
                var controller = new MFMessageComposeViewController();
                controller.Body = chatmessage.Body;
                controller.Recipients = new string[] { chatmessage.From };
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                    vc.PresentViewController(controller, true, () =>
                    {
                        sendmessage = true;
                    });
                    break;
                }
            }
            return sendmessage;
        }
    }
}