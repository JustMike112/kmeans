using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Assignment1_Kmeans.Utils;

namespace Assignment1_Kmeans.Algorithms
{
    class KMeans
    {
        private readonly int k = 5;
        private readonly int iterations = 100;

        public KMeans() { }

        public void Main(List<Point> points)
        {
            List<Centroid> centroids = new List<Centroid>();
            ISimilarity similarity = new Euclidean();

            // initialize centroids
            for (int i = 0; i < k; i++)
            {
                centroids.Add(new Centroid(i));
            }

            // main loop
            for (int i = 0; i < iterations; i++)
            {
                // clear point list
                for (int j = 0; j < k; j++)
                {
                    centroids[j].ClearPointList();
                }

                // assign points to centroid
                for (int p = 0; p < points.Count; p++)
                {
                    Tuple<double, int> smallestDistance = new Tuple<double, int>(double.MaxValue, 0);
                    for (int c = 0; c < centroids.Count; c++)
                    {
                        // calculate distance between point and centroid
                        double distance = similarity.Calculate(points[p].customerSales, centroids[c].Coordinates());
                        if (distance < smallestDistance.Item1)
                        {
                            smallestDistance = new Tuple<double, int>(distance, c);
                        }
                    }
                    // assign point to closest centroid
                    centroids[smallestDistance.Item2].AddPoint(points[p]);
                }

                // recalculate position of centroids
                for (int j = 0; j < k; j++)
                {
                    centroids[j].CalculateCentroidPosition();
                }

                // check if centroids have stopped moving
            }


            for (int x = 0; x < centroids.Count; x++)
            {
                Console.WriteLine(centroids[x].points.Count);
            }
        }

        private Dictionary<int, Dictionary<int, double>> CalculateDistanceMatrix(List<Point> points, ISimilarity similarity)
        {
            // create a triangle dictionary -> distance matrix
            Dictionary<int, Dictionary<int, double>> distanceMatrix = new Dictionary<int, Dictionary<int, double>>();

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    if (j < i)
                    {
                        continue;
                    }
                    double distance = similarity.Calculate(points[i].customerSales, points[j].customerSales.Select(x => (double)x).ToList());
                    distanceMatrix[i][j] = distance;
                }
            }

            return distanceMatrix;
        }
    }
}
