
using RCDriver.Common;
using SharpDX.XInput;
using System;
using System.Timers;

namespace RCDriver.MainApp
{
    //public abstract class XBoxPadSteeringWheel<T>:IController<T where T: RCDriver.Common.IVehicle, new()
    public abstract class XBoxPadSteeringWheel : IController
    {
        IVehicle vehicle;

        public event ControllerStateChangedHandler StateChanged;

        Controller xBoxController;
        State xBoxControllerState;
        ControllerState controllerState;
        Timer stateTimer;
        const double timerInterval = 100;//miliseconds


        public XBoxPadSteeringWheel(Controller controller)
        {
            this.xBoxController = controller;
            this.stateTimer = new Timer(timerInterval);
            this.stateTimer.Elapsed += stateTimer_Elapsed;
            this.stateTimer.AutoReset = true;
            this.stateTimer.Enabled = true;

        }

        public void SetVehicle(IVehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        void stateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            State currentState = this.xBoxController.GetState();

            if (!this.compareStates(currentState))
            {
                
                this.xBoxControllerState = currentState;

                if (vehicle != null)
                {
                    this.controllerState = this.mapControllerState(this.xBoxControllerState);
                    vehicle.UpdateState(this.controllerState);
                    
                }

                this.onStateChanged();

            }
        }

        private void onStateChanged()
        {
            if (this.StateChanged != null)
            {
                this.StateChanged(this, new ControllerStateEventArgs { State = this.controllerState });
            }
        }

        private bool compareStates(State stateToCompare)
        {
            return (stateToCompare.Gamepad.LeftThumbX != this.xBoxControllerState.Gamepad.LeftThumbX
                || stateToCompare.Gamepad.LeftThumbY != this.xBoxControllerState.Gamepad.LeftThumbY
                || stateToCompare.Gamepad.LeftTrigger != this.xBoxControllerState.Gamepad.LeftTrigger
                || stateToCompare.Gamepad.RightThumbX != this.xBoxControllerState.Gamepad.RightThumbX
                || stateToCompare.Gamepad.RightThumbY != this.xBoxControllerState.Gamepad.RightThumbY
                || stateToCompare.Gamepad.RightTrigger != this.xBoxControllerState.Gamepad.RightTrigger
                || stateToCompare.Gamepad.Buttons != this.xBoxControllerState.Gamepad.Buttons
                )
                ;
        }

        private ControllerState mapControllerState(State xBoxControllerState)
        {
            ControllerState state = new ControllerState();
            state.LeftTrigger = xBoxControllerState.Gamepad.LeftTrigger;
            state.RightTrigger = xBoxControllerState.Gamepad.RightTrigger;
            state.LeftSteering.X = shortPercentage(xBoxControllerState.Gamepad.LeftThumbX);
            state.LeftSteering.Y = shortPercentage(xBoxControllerState.Gamepad.LeftThumbY);
            state.RightSteering.X = shortPercentage(xBoxControllerState.Gamepad.RightThumbX);
            state.RightSteering.Y = shortPercentage(xBoxControllerState.Gamepad.RightThumbY);

            return state;
        }

        private double shortPercentage(short value)
        {
            return (value * 100) / short.MaxValue;
        }



    }
}
