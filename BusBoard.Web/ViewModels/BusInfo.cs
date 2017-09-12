using BusBoard.Api;
using System.Collections.Generic;
using System.Threading;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public BusInfo(string postCode)
        {
            PostCode = postCode;
            Coordinate = new Coordinate();
            BusStops = BusApi.GetTopReultsForPostcode(postCode, 5);
        }

        public BusInfo(Coordinate coordinate)
        {
            Coordinate = coordinate;
            BusStops = BusApi.GetTopReultsForCoordinate(coordinate, 5);
        }

        public string PostCode { get; set; }
        public Coordinate Coordinate { get; set; }
        public List<BusStop> BusStops { get; set; }

    }
}