using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HotelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelInfo" in both code and config file together.
    [ServiceContract]
    public interface IHotelInfoService
    {
        [OperationContract]
        [WebInvoke(Method="GET",UriTemplate ="GetAllHotels",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        List<Hotel> GetAllHotels();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetRoomsByHotel/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<rooms> GetRoomsByHotelId(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "BookRoom", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool BookRoom(BookingRequirement room);
    }
}
