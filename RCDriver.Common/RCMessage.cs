using System;
using Microsoft.SPOT;

namespace RCDriver.Common
{
    public class RCMessage
    {
        public Guid Id { get; set; }
        public MessageTypes MessageType { get; set; }

        public IVehicleModel Vehivle { get; set; }

    }
}
