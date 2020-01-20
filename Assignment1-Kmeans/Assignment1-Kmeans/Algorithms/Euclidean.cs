﻿using System;
using System.Collections.Generic;
using System.Text;
using Assignment1_Kmeans.Utils;

namespace Assignment1_Kmeans.Algorithms
{
    class Euclidean : ISimilarity
    {
        /* Euclidian formula : d(p,q) = sqrt(pow(p1-q1)+pow(pn-qn)) */

        public double Calculate(List<int> user, Centroid centroid)
        {
            var total = 0.0;

            for (var i = 0; i < user.Count; i++)
                total += Math.Pow(user[i] - centroid.Coordinates()[i], 2);

            return Math.Sqrt(total);
        }
    }
}
