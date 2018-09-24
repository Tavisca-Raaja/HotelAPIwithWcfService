using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class BookingRequirement
    {
        public string MailId { get; set; }
        public int HotelId { get; set; }
        public string RoomType { get; set; }
    }
}