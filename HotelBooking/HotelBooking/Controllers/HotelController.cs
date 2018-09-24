using HotelBooking.DataAccess;
using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelBooking.Controllers
{
    
    public class HotelController : ApiController
    {
        [HttpGet]
        [Route("api/Hotel/GetAllHotels")]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetAllHotels()
        {
            Logger.Instance.writeLog("GetAllHotels() api Call is Made");
            DataConnector hotels = new DataConnector();
            List<Hotel> hotelList = await hotels.GetAllData();
            if(hotelList.Count()==0)
            return Content(HttpStatusCode.NoContent, "No Hotels Found");
            Logger.Instance.writeLog("AllHotels returned successfully");
            return Ok(hotelList);
        }

        [HttpGet]
        [Route("api/Hotel/GetRoomsByHotelId/{hotelId}")]

        public async System.Threading.Tasks.Task<IHttpActionResult> GetRooms([FromUri]int hotelId)
        {
            Logger.Instance.writeLog("GetRooms api Call is Made");
            DataConnector hotels = new DataConnector();
            List<room> roomList = await hotels.GetRooms(hotelId);
            if (roomList.Count() == 0)
                return BadRequest("Invalid HotelId");
            Logger.Instance.writeLog("AllHotels returned successfully");
            return Ok(roomList);
        }

        [HttpPut]
        [Route("api/Hotel/BookRooms")]

        public async System.Threading.Tasks.Task<IHttpActionResult> BookRoom([FromBody] BookingRequirement updater)
        {
            Logger.Instance.writeLog("Booking Call is Made");
            DataConnector hotels = new DataConnector();
            if (await hotels.BookRoom(updater))
            {
                Logger.Instance.writeLog("Booked  Successfully");
                return Ok("Room Booked SuccessFully");
            }
           
            return  Content(HttpStatusCode.NoContent,"Rooms Are Filled");
        }
    }
}
