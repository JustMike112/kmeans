using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class CustomerData
    {
        private int customerID;
        private int offerID;
        private string customerName;

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
