using RCDriver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RCDriver.MainApp
{
    public class RCDriverServer
    {
        public List<IVehicle> Vehicles { get; private set; }
        public List<IController> Controllers { get; private set; }
        public CommunicationProtocol communicationProtocol { get; set; }

        public RCDriverServer(CommunicationProtocol communicationProtocol)
        {
            this.communicationProtocol = communicationProtocol;
            this.communicationProtocol.MessageReceived += communicationProtocol_MessageReceived;
        }

        void communicationProtocol_MessageReceived(CommunicationProtocol sender, RCMessageEventArgs e)
        {
            //po odebraniu komunkatu sprawdzamy co mozemy z nim zrobic np polaczyc sie z rc clientem
            switch (e.Message.MessageType)
            {
                case MessageTypes.Order:
                    break;
                case MessageTypes.Ping:
                    e.Message.MessageType = MessageTypes.Pong;
                    this.communicationProtocol.Send(e.Message);
                    break;
                case MessageTypes.Pong:
                    break;
                case MessageTypes.ConnectionRequest:

                    break;
                default:
                    break;
            }
        }


        public void AddController(IController controller)
        {
            controller.StateChanged += controller_StateChanged;
            this.Controllers.Add(controller);
        }

        void controller_StateChanged(IController sender, ControllerStateEventArgs e)
        {
            RCMessage message = new RCMessage();
            message.Id = Guid.NewGuid();
            message.MessageType = MessageTypes.Order;
            //todo uzupelnienie vehicla

            this.communicationProtocol.Send(message);

        }








    }
}
