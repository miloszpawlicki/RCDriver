using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCDriver
{
    public abstract class Vehicle<T> where T:IVehicleMessage
    {
        public string Serialize(T message)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(message);
        }

        public T Deserialize(string message)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(message);
        }
    }
}
