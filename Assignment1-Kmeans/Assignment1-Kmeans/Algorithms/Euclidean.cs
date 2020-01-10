using System;
using System.Collections.Generic;
using System.Text;
using Assignment1_Kmeans.Utils;

namespace Assignment1_Kmeans.Algorithms
{
    class Euclidean : ISimilarity
    {
        /* Euclidian formula : d(p,q) = sqrt(pow(p1-q1)+pow(pn-qn)) */

        public double Calculate(Point user1, Centroid centroid)
        {
            var length = user1.Size();
            var total = 0.0;

            for (var i = 0; i < length; i++)
                total += (Math.Pow(user1.customerID - centroid.X(), 2) + Math.Pow(user1.customerSales[i] - centroid.Y(), 2));

            return Math.Sqrt(total);
        }
    }
}
