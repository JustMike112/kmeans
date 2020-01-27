using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class CustomerData
    {
        public readonly int id;
        public readonly int offer;
        public readonly string name;

        public CustomerData(int customerID, int offerID, string customerName)
        {
            this.id = customerID;
            this.offer = offerID;
            this.name = customerName;
        }
    }
}
