using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.Api
{
    
    public class BusStop
    {
        [RestSharp.Deserializers.DeserializeAs(Name = "naptanId")]
        public string StopId { get; set; }

        [RestSharp.Deserializers.DeserializeAs(Name = "commonName")]
        public string StopName { get; set; }
        public List<BusArrival> BusArrivals { get; set; }

        [RestSharp.Deserializers.DeserializeAs(Name = "stopLetter")]
        public string StopLetter { get; set; }

        [RestSharp.Deserializers.DeserializeAs(Name = "long")]
        public string Longitude { get; set; }

        [RestSharp.Deserializers.DeserializeAs(Name = "lat")]
        public string Latitude { get; set; }


        public void refreshArrivals()
        {
            BusArrivals = BusApi.GetBusArivalsForStop(this);
        }
    }

}
