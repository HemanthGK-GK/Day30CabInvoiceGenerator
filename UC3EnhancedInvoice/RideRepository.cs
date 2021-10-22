using System;
using System.Collections.Generic;
using System.Text;

namespace UC3EnhancedInvoice
{
    class RideRepository
    {
        Dictionary<string, List<Ride>> userRide = null;

       public RideRepository()
        {
            this.userRide = new Dictionary<string, List<Ride>>();

        }
        public void AddRide(string userID,Ride[] rides)
        {
            bool riderList = this.userRide.ContainsKey(userID);
            try
            {
                if(!riderList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRide.Add(userID, list);
                }
            }
            catch(CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_RIDER, "Rides are Null");
            }

        }
        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRide[userId].ToArray();
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.INVALID_USERID, "Invalid User ID");
            }

        }
    }
}
