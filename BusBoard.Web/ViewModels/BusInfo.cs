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
        }

        public BusInfo(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public string PostCode { get; set; }
        public Coordinate Coordinate { get; set; }
        public List<BusStop> BusStops { get; set; }

        public void AddBusStops(List<BusStop> busStops)
        {
            foreach(var busStop in busStops)
            {
                AddBusStop(busStop);
            }
        }

        public void AddBusStop(BusStop busStop)
        {
            BusStops.Add(busStop);
        }

        public void UpdateBusStopsFromApi()
        {
            try
            {
                if (Coordinate.Latitude != null && Coordinate.Longitude != null)
                {
                    BusStops = BusApi.GetTopReultsForCoordinate(Coordinate, 5);
                }
                else
                {
                    BusStops = BusApi.GetTopReultsForPostcode(PostCode, 5);
                }
            }
            catch { }
        }
    }

}