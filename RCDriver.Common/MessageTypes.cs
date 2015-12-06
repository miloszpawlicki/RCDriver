using System;
using Microsoft.SPOT;

namespace RCDriver.Common
{
    public enum MessageTypes
    {
        Order, Ping, Pong, ConnectionRequest, ConnectionRequestAccepted, ConnectionRequestAcceptationConfirmation
    }
}
