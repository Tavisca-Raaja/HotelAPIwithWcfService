using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelBooking.DataAccess
{
    public class BookingUpdater
    {
        private SqlConnection _Connection;
        private SqlConnectionStringBuilder _Connector;
        public BookingUpdater()
        {
            _Connection = new SqlConnection();
            try
            {
                _Connector = new SqlConnectionStringBuilder();
                _Connector.DataSource = "localhost";
                _Connector.UserID = "sa";
                _Connector.Password = "test123!@#";
                _Connector.InitialCatalog = "HotelProduct";
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        public void UpdateBooking(BookingRequirement user)
        {
            using (_Connection = new SqlConnection(_Connector.ConnectionString))
            {
                _Connection.Open();
                string InsertQuery = "Insert into Booking values(@hotelId,@roomType,@email)";
                using (SqlCommand command = new SqlCommand(InsertQuery, _Connection))
                {
                    command.Parameters.AddWithValue("@hotelId", user.HotelId);
                    command.Parameters.AddWithValue("@roomType", user.RoomType);
                    command.Parameters.AddWithValue("@email", user.MailId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}