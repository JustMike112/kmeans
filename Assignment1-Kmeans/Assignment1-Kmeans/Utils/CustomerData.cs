using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class CustomerData
    {
        public readonly int customerID;
        public readonly int offerID;
        public readonly string customerName;

        public CustomerData(int customerID, int offerID, string customerName)
        {
            this.customerID = customerID;
            this.offerID = offerID;
            this.customerName = customerName;
        }

        public CustomerData(int customerID, int offerID)
        {
            this.customerID = customerID;
            this.offerID = offerID;
        }

    }
}
