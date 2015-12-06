using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCDriver.MainApp
{
    public struct ControllerState
    {
        public ControllerStateThumb LeftSteering;
        public ControllerStateThumb RightSteering;
        public double LeftTrigger { get; set; }
        public double RightTrigger { get; set; }
        public bool ArrowUp { get; set; }
        public bool ArrowDown { get; set; }
        public bool ArrowLeft { get; set; }
        public bool ArrowRight { get; set; }
        public bool Start { get; set; }
        public bool Back { get; set; }
        public bool LeftShoulder { get; set; }
        public bool RightShoulder { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }
        public bool X { get; set; }
        public bool Y { get; set; }


    }
}
