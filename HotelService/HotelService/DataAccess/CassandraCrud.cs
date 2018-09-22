using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HotelService.DataAccess
{
    public class CassandraCrud
    {
        Cluster connection;
        ISession session;

        public CassandraCrud()
        {
            connection = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = connection.Connect("hotelproduct");
        }
        public List<Hotel> GetAll()
        {
            List<Hotel> HotelsList = new List<Hotel>();
            Hotel details;
            var selectQuery = session.Prepare("select * from hotel");
            var command = selectQuery.Bind();
            var result= session.Execute(command);
            foreach(var Datarows in result)
            {
                details = new Hotel();
                details.hotelId = Datarows.GetValue<Int32>("hotel_id");
                details.hotelName = Datarows.GetValue<string>("hotel_name");
                details.contactNumber = Datarows.GetValue<string>("contact_number");
                details.Address = Datarows.GetValue<string>("hotel_address");
                details.starRating = Datarows.GetValue<Int32>("star_rating");
                HotelsList.Add(details);
            }
            return HotelsList;
        }

        public List<rooms> GetRoomsByHotel(int id)
        {
            List<rooms> availableRooms = new List<rooms>();
            rooms room;
            var selectQuery = session.Prepare("select * from rooms where hotelid=?");
            var command = selectQuery.Bind(id);
            var result = session.Execute(command);
            foreach(var Datarows in result)
            {
                room = new rooms();
                room.hotelId = Datarows.GetValue<Int32>("hotelid");
                room.roomType = Datarows.GetValue<string>("roomtype");
                room.availableRooms = Datarows.GetValue<int>("availablerooms");
                room.price = Datarows.GetValue<decimal>("price");
                room.guestCount= Datarows.GetValue<Int32>("guestcount");
                availableRooms.Add(room);
            }
            return availableRooms;
        }

        public bool UpdateRoomStatus(int id,string roomType)
        {
            var selectQuery = session.Prepare("select availablerooms from rooms where hotelid=? and roomtype=?");
            var command = selectQuery.Bind(id,roomType);
            var result = session.Execute(command).First();
            if (result.GetValue<Int32>("availablerooms")==0)
                return false;
            var UpdateQuery = session.Prepare("Update rooms set availablerooms=? where hotelid=? and roomtype=?");
            var UpdateBinder = UpdateQuery.Bind(result.GetValue<Int32>("availablerooms")-1,id,roomType);
            session.Execute(UpdateBinder);
            return true;
        }

    }
}