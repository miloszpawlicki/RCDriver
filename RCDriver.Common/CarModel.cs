using System;

namespace RCDriver.Common
{
    public class CarModel: IVehicleModel
    {
        public Guid Id { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public string Name { get; set; }

        public int EngineSpeed { get; set; }
        public int TurnPosition { get; set; }
        public bool LightsStatus { get; set; }

     



       
    }
}
