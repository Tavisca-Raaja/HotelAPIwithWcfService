using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService
{
    public class rooms
    {
        public int hotelId { get; set; }
        public string roomType { get; set; }

        public int availableRooms { get; set; }
        public int guestCount { get; set; }
        public decimal price { get; set; }

    }
}