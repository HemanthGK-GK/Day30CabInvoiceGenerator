using System;

namespace UC3EnhancedInvoice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cab Fare Generator");
            InvoiceGenerator iGen = new InvoiceGenerator(RideType.NORMAL);
            double fare = iGen.calculateFare(2.0, 5);
            Console.WriteLine(fare);
        }
    }
}
