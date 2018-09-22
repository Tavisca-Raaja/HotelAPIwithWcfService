using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.DataAccess
{
    public class Logger
    {

        Cluster connection;
        ISession session;
        private static Logger _instance;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logger();
                return _instance;
            }
        }
        Logger()
        {
            connection = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = connection.Connect("hotelproduct");
        }
   

        public void writeLog(string comment)
        {
            var InsertQuery = session.Prepare("Insert into Logger (datetime,comment)values(now(),?)");
            var command = InsertQuery.Bind(comment);
            session.Execute(command);
        }
    }
}