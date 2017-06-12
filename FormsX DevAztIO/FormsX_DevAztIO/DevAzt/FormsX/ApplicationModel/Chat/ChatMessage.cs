using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAzt.FormsX.ApplicationModel.Chat
{
    public class ChatMessage
    {

        public string Body { get; set; }

        public string Subject { get; set; }

        public string From { get; set; }

        public bool IsRead { get; set; }

        public bool IsSeen { get; set; }

        public ChatType Type { get; set; }
    }
}
