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

        public void refreshArrivals()
        {
            BusArrivals = BusApi.GetBusArivalsForStop(this);
        }
    }

}
