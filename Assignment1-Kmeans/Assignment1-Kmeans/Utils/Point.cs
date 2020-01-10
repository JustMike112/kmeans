﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class Point
    {
        public int customerID;
        public int centroid;
        public List<int> customerSales;

        public Point() { }
        
        public Point(int customerID)
        {
            this.customerID = customerID;
        }

        public Point(int customerID, List<int> customerSales)
        {
            this.customerID = customerID;
            this.customerSales = customerSales;
        }

        public void AddSales(int sale)
        {
            this.customerSales.Add(sale);
        }
        
        public void AssignToCentroid(int centroid)
        {
            this.centroid = centroid;
        }

        public int Size()
        {
            return customerSales.Count;
        }

    }
}
