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
        //[DeserializeAs(Name = "longitude")]
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
