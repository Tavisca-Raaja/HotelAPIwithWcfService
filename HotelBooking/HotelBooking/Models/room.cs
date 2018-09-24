using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class room
    {
        public string RoomType { get; set; }

        public int availableRooms { get; set; }
        public int guestCount { get; set; }
        public decimal price { get; set; }
        public int SquareFeet { get; set; }

        public string Bed { get; set; }
        public string Aminities { get; set; }
        public string offers { get; set; }

    }
}