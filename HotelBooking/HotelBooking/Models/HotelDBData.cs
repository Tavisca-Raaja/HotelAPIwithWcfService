using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class HotelDBData
    {
        public int Hotelid { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int StarRating { get; set; }

    }
}