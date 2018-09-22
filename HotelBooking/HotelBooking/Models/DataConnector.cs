using HotelBooking.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace HotelBooking.Models
{
    public class DataConnector
    {
        public async System.Threading.Tasks.Task<List<HotelDBData>> GetDbData()
        {
            List<HotelDBData> WcfServiceData = new List<HotelDBData>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:57896/HotelInfoService.svc/GetAllHotels");
                if (response.StatusCode == HttpStatusCode.OK)
                    WcfServiceData = await response.Content.ReadAsAsync<List<HotelDBData>>();
            }
            return WcfServiceData;
        }

        public async System.Threading.Tasks.Task<List<HotelDetails>> GetLocalData()
        {
            List<HotelDetails> JsonData = new List<HotelDetails>();
            using (StreamReader r = new StreamReader(@"C:\\Users\\rgouthaman\\source\\repos\\HotelBooking\\LocalData.json"))
            {
                string json = r.ReadToEnd();
                JsonData = JsonConvert.DeserializeObject<List<HotelDetails>>(json);
            }
            return JsonData;
        }

        public async System.Threading.Tasks.Task<List<Hotel>> GetAllData()
        {
            List<HotelDBData> ServiceDetails = await GetDbData();
            List<HotelDetails> LocalData = await GetLocalData();
            List<Hotel> EntireData = new List<Hotel>();
            foreach (var hotels in ServiceDetails)
            {
                Hotel data = new Hotel();
                data.HotelId = hotels.Hotelid;
                data.HotelName = hotels.HotelName;
                data.Address = hotels.Address;
                data.ContactNumber = hotels.ContactNumber;
                data.StarRating = hotels.StarRating;
                HotelDetails staticDetails = LocalData.Single(extract => (extract.HotelId == hotels.Hotelid));
                data.Aminities = staticDetails.Aminities;
                data.ParkingFacility = staticDetails.Parking;
                data.BreakFast = staticDetails.BreakFast;
                data.CancellationPolicy = staticDetails.CancellationPolicy;
                data.HotelImageUrl = staticDetails.HotelImageUrl;
                EntireData.Add(data);
            }
            return EntireData;
        }

        public async System.Threading.Tasks.Task<List<RoomDescription>> GetRoomsData(int hotelId)
        {
            List<RoomDescription> WcfServiceData = new List<RoomDescription>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:57896/HotelInfoService.svc/GetRoomsByHotel/" + hotelId);
                if (response.StatusCode == HttpStatusCode.OK)
                    WcfServiceData = await response.Content.ReadAsAsync<List<RoomDescription>>();
            }
            return WcfServiceData;
        }

        public async System.Threading.Tasks.Task<List<Roomsdata>> GetRoomsAminities()
        {
            List<Roomsdata> JsonData = new List<Roomsdata>();
            using (StreamReader r = new StreamReader(@"C:\\Users\\rgouthaman\\source\\repos\\HotelBooking\\RoomsData.json"))
            {
                string json = r.ReadToEnd();
                JsonData = JsonConvert.DeserializeObject<List<Roomsdata>>(json);
            }
            return JsonData;
        }
        public async System.Threading.Tasks.Task<List<room>> GetRooms(int hotelId)
        {
            List<RoomDescription> ServiceDetails = await GetRoomsData(hotelId);
            List<Roomsdata> LocalData = await GetRoomsAminities();
            List<room> EntireData = new List<room>();
            foreach (var roomDescription in ServiceDetails.FindAll(extract => extract.HotelId == hotelId).ToList())
            {
                room data = new room();
                data.RoomType = roomDescription.RoomType;
                data.price = roomDescription.price;
                data.availableRooms = roomDescription.availableRooms;
                data.guestCount = roomDescription.guestCount;
                data.availableRooms = roomDescription.availableRooms;
                var innerAminities = LocalData.Single(extract => extract.RoomType == roomDescription.RoomType && extract.HotelId == hotelId);
                data.SquareFeet = innerAminities.SquareFeet;
                data.Bed = innerAminities.Bed;
                data.Aminities = innerAminities.Aminities;
                data.offers = innerAminities.offers;
                EntireData.Add(data);
            }
            return EntireData;
        }

        public async System.Threading.Tasks.Task<bool> BookRoom(BookingRequirement updater)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync("http://localhost:57896/HotelInfoService.svc/BookRoom", updater);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    BookingUpdater booker = new BookingUpdater();
                    booker.UpdateBooking(updater);
                    return true;
                }
            }
            return false;
        }
    }

}