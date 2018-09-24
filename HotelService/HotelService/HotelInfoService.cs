using HotelService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HotelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelInfo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelInfo.svc or HotelInfo.svc.cs at the Solution Explorer and start debugging.
    public class HotelInfoService : IHotelInfoService
    {
        CassandraCrud operation = new CassandraCrud();

        public bool BookRoom(BookingRequirement updater)
        {
           
            return operation.UpdateRoomStatus(updater.HotelId,updater.RoomType);
        }

        public List<Hotel> GetAllHotels()
        {
           
            return operation.GetAll();
        }

        public List<rooms> GetRoomsByHotelId(string id)
        {
            int hotelId;
            int.TryParse(id,out hotelId);
            return operation.GetRoomsByHotel(hotelId);
        }
    }
}
