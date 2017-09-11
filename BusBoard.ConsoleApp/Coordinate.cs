using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class Coordinate
    {
        [RestSharp.Deserializers.DeserializeAs(Name = "result.longitude")]
        public string Longitude { get; set; }

        [RestSharp.Deserializers.DeserializeAs(Name = "result.latitude")]
        public string Latitude { get; set; }
    }
}
