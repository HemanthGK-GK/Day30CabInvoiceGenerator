using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabFareTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [Test]
        public void GivenDistance()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            double fare = invoiceGenerator.calculateFare(distance, time);
            double expected = 25;

            Assert.AreEqual(fare, expected);
        }

        public void MultipleRides()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 2) };
            InvoiceSummary invoiceSummary = invoiceGenerator.calculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expected, invoiceSummary);

        }
        [TestMethod]
        public void ListFareForMultipleRides()
        {
            
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(5, 15));
            rides.Add(new Ride(5, 30));

            
            double totalFare = invoiceGenerator.CalculateFare(rides);
            double expected = 130;
            Assert.AreEqual(expected, totalFare);
        }



    }
}