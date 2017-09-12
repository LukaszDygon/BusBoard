using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using BusBoard.Api;

namespace BusBoard.ConsoleApp
{
    class UserConsole
    {
        public void Run()
        {
            while (true)
            {
                Console.Write(">");
                string userInput = Console.ReadLine();
                try
                {
                    var closestBusStops = BusApi.GetTopReultsForPostcode(userInput, 5);

                    printTopResults(closestBusStops[0]);
                    printTopResults(closestBusStops[1]);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid address {e}");
                }
            }
        }

        private void printTopResults(BusStop arrivals)
        {
            foreach (var arrival in arrivals.BusArrivals)
            {
                printSingleResult(arrival);
            }
        }

        private void printSingleResult(BusArrival info)
        {
            Console.WriteLine($"{info.LineName} towards {info.DestinationName}");
            Console.WriteLine(info.ExpectedArrival.ToLocalTime());
            Console.WriteLine("\n");

        }
    }
}
