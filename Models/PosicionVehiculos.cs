using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIT.Models
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datum2
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public DateTime time { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double heading { get; set; }
        public double speed { get; set; }
        public ReverseGeo reverseGeo { get; set; }
    }

    public class Pagination
    {
        public string endCursor { get; set; }
        public bool hasNextPage { get; set; }
    }

    public class ReverseGeo
    {
        public string formattedLocation { get; set; }
    }

    public class RootObject
    {
        public List<Datum2> data { get; set; }
        public Pagination pagination { get; set; }
    }


}
