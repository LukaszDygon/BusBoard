using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class UserConsole
    {
        public void Run()
        {
            while (true)
            {
                Console.Write(">");
                string[] userInput = Console.ReadLine().Split(' ');
                try
                {
                    //printTopResults(userInput[0], 5);
                    var location = GetCoordinatesFromPostCode(userInput[0]);
                    var closestBusStops = GetStationId(location);
                    Console.WriteLine($"{closestBusStops[0].StopId}");


                    printTopResults(closestBusStops[0].StopId, 5);


                    printTopResults(closestBusStops[1].StopId, 5);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid address {e}");
                }
            }
        }

        private void printTopResults(string stopId, int numberOfResults)
        {
            var arrivals = GetBusArivalsForStop(stopId);
            var topResults = getTopResults(arrivals, numberOfResults);
            foreach (var result in topResults)
            {
                printSingleResult(result);
            }
        }

        private void printSingleResult(BusArrival info)
        {
            Console.WriteLine($"{info.LineName} towards {info.DestinationName}");
            Console.WriteLine(info.ExpectedArrival.ToLocalTime());
            Console.WriteLine("\n");

        }

        private List<BusArrival> getTopResults(List<BusArrival> arrivals, int numberOfResults)
        {
            var topResults = arrivals.OrderBy(x => x.ExpectedArrival).Take(numberOfResults).ToList();

            return topResults;
        }

        private List<BusArrival> GetBusArivalsForStop(string stopId)
        {
            var client = new RestClient(@"https://api.tfl.gov.uk");
            var request = new RestRequest($@"StopPoint/{stopId}/Arrivals", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<List<BusArrival>>(request);

            return response.Data;
        }

        private Coordinate GetCoordinatesFromPostCode(string postCode)
        {
            var client = new RestClient(@"https://api.postcodes.io");
            var request = new RestRequest($@"postcodes/{postCode}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<Coordinate>(request);

            //Console.WriteLine(response.Data);

            Console.WriteLine(response.Data.Latitude);
            Console.WriteLine(response.Data.Longitude);

            return response.Data;
        }

        private List<BusStop> GetStationId(Coordinate location)
        {
            var client = new RestClient(@"https://api.tfl.gov.uk");
            var request = new RestRequest($@"StopPoint?lat={location.Latitude}&lon={location.Longitude}"+
                                            "&stoptypes=NaptanPublicBusCoachTram&modes=bus", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<BusStopResponse>(request);
            Console.WriteLine($"the stop ID {response.Data.BusStops[0].StopId}");

            return response.Data.BusStops;

        }
    }
}
