using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string stopId = "490008660N";
            PrintBusArivalsForStop(stopId);
            Console.ReadKey();
        }

        static void PrintBusArivalsForStop(string stopId)
        {
            var client = new RestClient("https://api-radon.tfl.gov.uk/");
            //var request = new RestRequest(String.Format(@"StopPoint/{0}/Arrivals", stopId), Method.GET);
            var request = new RestRequest("StopPoint/490008660N/Arrivals", Method.GET);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.StatusCode);
        }
    }
}
