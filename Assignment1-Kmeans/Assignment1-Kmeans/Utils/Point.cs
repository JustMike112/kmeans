using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class Point
    {
        public int id;
        public int centroid;
        public string name;
        public List<int> purchases = new List<int>();

        public Point() { }
        
        public Point(int customerID)
        {
            this.id = customerID;
        }

        public Point(int customerID, string name)
        {
            this.id = customerID;
            this.name = name;
        }

        public Point(int customerID, List<int> customerSales)
        {
            this.id = customerID;
            this.purchases = customerSales;
        }

        public void AddSales(int sale)
        {
            this.purchases.Add(sale);
        }
        
        public void AssignToCentroid(int centroid)
        {
            this.centroid = centroid;
        }
        
    }
}
