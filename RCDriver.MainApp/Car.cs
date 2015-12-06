using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCDriver.MainApp
{
    public class Car:IVehicle
    {
        public RCDriver.Common.CarModel CarModel { get; set; }

        public void UpdateState(ControllerState state)
        {
            throw new NotImplementedException();
        }
    }
}
