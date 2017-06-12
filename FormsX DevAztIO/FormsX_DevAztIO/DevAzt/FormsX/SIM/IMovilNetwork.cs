
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAzt.FormsX.ApplicationModel.Chat;

namespace DevAzt.FormsX.SIM
{
    public interface IMovilNetwork
    {

        bool SendMessage(ChatMessage chatmessage);

    }
}
