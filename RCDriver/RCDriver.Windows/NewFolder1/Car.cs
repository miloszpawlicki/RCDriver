using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCDriver
{
    public class Car: Vehicle<Car>,IVehicleMessage
    {
        CommunicationProtocol protocol = new CommunicationProtocol();

        public Guid Id { get; set; }
        public int EngineSpeed { get; set; }
        public int TurnPosition { get; set; }
        public bool LightsStatus { get; set; }

        public void MoveForward(int speed)
        {

        }

        public void MoveBackward(int speed)
        {

        }

        public void Turn(int degree)
        {

        }

        public void Break(int push)
        {

        }

        public void LightsOn()
        {
            LightsStatus = true;
        }

        public void LightsOf()
        {
            LightsStatus = false;
        }
    }
}
