using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class Point
    {
        public int id;
        public string name;
        public List<int> purchases = new List<int>();
        
        public Point(int customerID, string name)
        {
            this.id = customerID;
            this.name = name;
        }

        public void AddSales(int sale)
        {
            this.purchases.Add(sale);
        }        
    }
}
