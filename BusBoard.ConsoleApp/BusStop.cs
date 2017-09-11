using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class BusStop
    {
        [RestSharp.Deserializers.DeserializeAs(Name = "naptanId")]
        public string StopId { get; set; }
    }
}
