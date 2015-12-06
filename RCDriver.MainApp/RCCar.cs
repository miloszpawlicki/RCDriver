using RCDriver.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCDriver.MainApp
{
    public class RCCar
    {
        CarModel car;

        public RCCar()
        {
            this.car = new CarModel();
        }

        public void UpdateState(IControllerState state)
        {
            
        }
    }
}
