using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCDriver.MainApp
{
    public delegate void ControllerStateChangedHandler(IController sender, ControllerStateEventArgs e);
    public interface IController//<T>
    {
        event ControllerStateChangedHandler StateChanged;
    }
}
