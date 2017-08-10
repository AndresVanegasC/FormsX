using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevAzt.FormsX.ApplicationModel.Chat;
using DevAzt.FormsX.SIM;
using Xamarin.Forms;

[assembly: Dependency(typeof(DevAzt.FormsX.UWP.SIM.MovilNetwork))]
namespace DevAzt.FormsX.UWP.SIM
{
    public class MovilNetwork : IMovilNetwork
    {
        public bool SendMessage(ChatMessage chatmessage)
        {
            var chatMessage = new Windows.ApplicationModel.Chat.ChatMessage();
            if (chatmessage != null)
            {
                chatMessage.Body = chatmessage.Body;
                chatMessage.Subject = chatmessage.Subject;
                chatMessage.Recipients.Add(chatmessage.From);
            }
            var result = Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
            result.GetResults();
            return true;
        }
    }
}