using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Roomsdata
    {
        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public int SquareFeet { get; set; }
        public string Bed { get; set; }
        public string Aminities { get; set; }
        public string offers { get; set; }
    }
}