using BusBoard.Api;
using System.Collections.Generic;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public BusInfo(string postCode)
        {
            PostCode = postCode;
            BusStops = BusApi.GetTopReultsForPostcode(postCode, 5);
        }

        public string PostCode { get; set; }
        public List<BusStop> BusStops { get; set; }

    }
}