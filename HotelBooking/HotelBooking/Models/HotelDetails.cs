using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class HotelDetails
    {
        public int HotelId { get; set; }
        public string Aminities { get; set; }
        public string Parking { get; set; }
        public string BreakFast { get; set; }
        public string CancellationPolicy { get; set; }
        public string HotelImageUrl { get; set; }
    }
}