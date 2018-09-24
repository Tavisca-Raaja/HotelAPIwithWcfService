using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cassandra;

namespace HotelService
{
    public class Hotel
    {
        public int hotelId { get; set; }
        public string contactNumber { get; set; }
        public string Address { get; set; }
        public string hotelName { get; set;}
        public int starRating { get; set; }

      
    }
}