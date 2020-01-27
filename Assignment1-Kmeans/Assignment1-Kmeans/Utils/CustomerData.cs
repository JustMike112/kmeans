using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class CustomerData
    {
        public int id;
        public int offer;
        public string name;

        public CustomerData(int customerID, int offerID, string customerName)
        {
            this.id = customerID;
            this.offer = offerID;
            this.name = customerName;
        }
    }
}
