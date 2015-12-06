using System;

namespace RCDriver.Common
{
    public interface IVehicleModel
    {
        Guid Id { get; set; }
        VehicleTypes VehicleType { get; set; }
        String Name { get; set; }
    }
}
