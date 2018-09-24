using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int StarRating { get; set; }
        public string Aminities { get; set; }
        public string ParkingFacility { get; set; }
        public string BreakFast { get; set; }
        public string CancellationPolicy { get; set; }
        public string HotelImageUrl { get; set; }
    }
}