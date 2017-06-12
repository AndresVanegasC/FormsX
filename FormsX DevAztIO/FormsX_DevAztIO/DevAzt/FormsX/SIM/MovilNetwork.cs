using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevAzt.FormsX.ApplicationModel.Chat;
using Xamarin.Forms;

namespace DevAzt.FormsX.SIM
{
    public class MovilNetwork : IMovilNetwork
    {
        private IMovilNetwork _service { get; set; }

        public MovilNetwork(IMovilNetwork service)
        {
            _service = service;
        }

        public bool SendMessage(ChatMessage chatmessage)
        {
            return _service.SendMessage(chatmessage);
        }

        public static MovilNetwork Instance
        {
            get
            {
                var dependency = DependencyService.Get<IMovilNetwork>();
                if (dependency != null)
                {
                    return new MovilNetwork(dependency);
                }
                throw new Exception("La dependencia de servicio no puede ser null, asegurese de la implementación en la plataforma");
            }
        }
    }
}
