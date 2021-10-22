using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
   public class InvoiceSummary
    {
        private int numOfRides;
        private double totalFare;
        private double avgFare;

        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.avgFare = this.totalFare / this.numOfRides;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if(!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputObj = (InvoiceSummary)obj;

            return this.numOfRides == inputObj.numOfRides && this.totalFare == inputObj.totalFare&&
                this.avgFare==inputObj.avgFare;
        }

        public override int GetHashCode()
        {
            return this.numOfRides.GetHashCode();
        }
    }
}
