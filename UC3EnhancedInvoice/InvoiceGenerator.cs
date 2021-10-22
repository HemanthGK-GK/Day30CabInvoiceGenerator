using System;
namespace UC3EnhancedInvoice
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;
        private double MIN_COST_PER_KM;
        private int COST_PER_TIME;
        private double MIN_FARE;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();

            try
            {
                if (rideType.Equals(RideType.PREMIER))
                {
                    this.MIN_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MIN_FARE = 20;
                }
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MIN_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MIN_FARE = 5;
                }

            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.INVALID_RIDE_TYPE, "Invalid RideType");
            }
        }
            public double calculateFare(double distance, int time)
            {
                double totalFare = 0;
                try
                {
                    totalFare = distance * MIN_COST_PER_KM + time * COST_PER_TIME;
                }
            catch (CustomException)
            {
                if(rideType == null)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_RIDE_TYPE, "Invalid RideType");
                }


                if (distance <= 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time <= 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
             }
            return Math.Max(totalFare, MIN_FARE);

        }

            public InvoiceSummary calculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    totalFare += this.calculateFare(ride.distance, ride.time);
                }
            }
            catch(CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_RIDER, "Rides are Null");
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }

        public void AddRides(string userId,Ride[] rides)
        {
            try
            {
                rideRepository.AddRide(userId, rides);
            }
            catch(CustomException)
            {
                if( rides == null)
                {
                    throw new CustomException(CustomException.ExceptionType.NULL_RIDER, "Rides are Null");
                }
            }
        }

        public InvoiceSummary getInvoiceSummary(string userId)
        {
            try
            {
               return this.calculateFare(rideRepository.GetRides(userId));
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.INVALID_USERID, "Invalid UserID");
            }
        }



        }
    }

       
