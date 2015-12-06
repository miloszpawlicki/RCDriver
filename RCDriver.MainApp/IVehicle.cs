using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCDriver.MainApp
{
    public interface IVehicle
    {
        void UpdateState(ControllerState state);
    }
}
