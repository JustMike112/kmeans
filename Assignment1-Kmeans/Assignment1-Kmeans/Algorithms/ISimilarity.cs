using System;
using System.Collections.Generic;
using System.Text;
using Assignment1_Kmeans.Utils;

namespace Assignment1_Kmeans.Algorithms
{
    interface ISimilarity
    {
        double Calculate(List<int> user, List<double> centroid);
    }
}
