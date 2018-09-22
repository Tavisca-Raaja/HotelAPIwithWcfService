using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class RoomDescription
    {
      public int HotelId { get; set; }
      public string RoomType { get; set; }
      public int availableRooms { get; set; }
      public int guestCount { get; set; }
      public decimal price { get; set; }

    }
}