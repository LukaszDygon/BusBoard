using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string stopId = "490008660N";
            PrintBusArivalsForStop(stopId);
            Console.ReadKey();
        }

        static void PrintBusArivalsForStop(string stopId)
        {
            var client = new RestClient(@"https://api.tfl.gov.uk");
            var request = new RestRequest($@"StopPoint/{stopId}/Arrivals", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<List<BusArrival>>(request);
            
            foreach(var r in response.Data)
            {
                Console.WriteLine(r.ExpectedArrival);
            }
            
            Console.WriteLine(response.Data);
        }
    }
}
