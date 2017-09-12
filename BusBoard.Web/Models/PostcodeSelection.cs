using BusBoard.Api;

namespace BusBoard.Web.Models
{
  public class PostcodeSelection
  {
    public string Postcode { get; set; }
    public Coordinate Location { get; set; }

  }
}