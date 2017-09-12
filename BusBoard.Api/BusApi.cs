using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoard.Api
{
    public class BusApi
    {
        public static List<BusStop> GetTopReultsForPostcode(string postcode, int numberOfResults)
        {
            var location = GetCoordinatesFromPostCode(postcode);
            List<BusStop> busStops = GetStationId(location);
            //var busArrivals = new List<List<BusArrival>>();
            try
            {
                foreach (var busStop in busStops)
                {
                    var arrivals = GetBusArivalsForStop(busStop);
                    busStop.BusArrivals = GetTopResults(arrivals, numberOfResults);
                }
            }
            catch (Exception e)
            {
            }

            return busStops;
        }

        public static List<BusArrival> GetBusArivalsForStop(BusStop busStop)
        {
            var client = new RestClient(@"https://api.tfl.gov.uk");
            var request = new RestRequest($@"StopPoint/{busStop.StopId}/Arrivals", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<List<BusArrival>>(request);

            return response.Data;
        }

        private static List<BusArrival> GetTopResults(List<BusArrival> arrivals, int numberOfResults)
        {
            var topResults = arrivals.OrderBy(x => x.ExpectedArrival).Take(numberOfResults).ToList();

            return topResults;
        }

        

        private static Coordinate GetCoordinatesFromPostCode(string postCode)
        {
            var client = new RestClient(@"https://api.postcodes.io");
            var request = new RestRequest($@"postcodes/{postCode}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<Coordinate>(request);

            return response.Data;
        }

        private static List<BusStop> GetStationId(Coordinate location)
        {
            var client = new RestClient(@"https://api.tfl.gov.uk");
            var request = new RestRequest($@"StopPoint?lat={location.Latitude}&lon={location.Longitude}" +
                                            "&stoptypes=NaptanPublicBusCoachTram&modes=bus", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<BusStopResponse>(request);

            return response.Data.BusStops;
        }
    }
}
