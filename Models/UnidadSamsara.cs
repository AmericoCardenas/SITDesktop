using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIT.Models
{
    public class ExternalIds
    {
        public string samsaraserial { get; set; }
        public string samsaravin { get; set; }
    }

    public class Gateway
    {
        public string serial { get; set; }
        public string model { get; set; }
    }

    public class StaticAssignedDriver
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Datum
    {
        public string cameraSerial { get; set; }
        public ExternalIds externalIds { get; set; }
        public Gateway gateway { get; set; }
        public string harshAccelerationSettingType { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string serial { get; set; }
        public StaticAssignedDriver staticAssignedDriver { get; set; }
        public string vin { get; set; }
        public string vehicleRegulationMode { get; set; }
        public string createdAtTime { get; set; }
        public string updatedAtTime { get; set; }
        public string esn { get; set; }
    }

    public class Root
    {
        public List<Datum> data { get; set; }
    }

}
