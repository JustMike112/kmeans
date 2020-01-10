using System;
using System.Collections.Generic;
using System.Text;
using Assignment1_Kmeans.Utils;

namespace Assignment1_Kmeans.Algorithms
{
    interface ISimilarity
    {
        double Calculate(Point user, Centroid centroid);
    }
}
