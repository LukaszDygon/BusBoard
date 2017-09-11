using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class BusStopResponse
    {
        public string Type { get; set; }

        public string CentrePoint { get; set; }

        [RestSharp.Deserializers.DeserializeAs(Name = "stopPoints")]
        public List<BusStop> BusStops { get; set; }
    }
}
