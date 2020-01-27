using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Assignment1_Kmeans.Utils;

namespace Assignment1_Kmeans.Algorithms
{
    class KMeans
    {
        private readonly int k = 4;
        private readonly int iterations = 100;

        private List<Point> points;
        private List<Centroid> centroids = new List<Centroid>();
        public Dictionary<int, Dictionary<int, double>> distanceMatrix;
        private ISimilarity similarity = new Euclidean();
        public Tuple<List<Centroid>, double> bestValues;
        private int actualIterations;

        public KMeans()
        {
            points = Parser.Parse(';', "wineKMCWithNames.csv");
            distanceMatrix = CalculateDistanceMatrix();
        }

        public KMeans(int clusters)
        {
            k = clusters;
            points = Parser.Parse(';', "wineKMCWithNames.csv");
            distanceMatrix = CalculateDistanceMatrix();
        }

        public void Main()
        {
            for (int runs = 0; runs < iterations; runs++)
            {
                // initialize centroids
                for (int i = 0; i < k; i++)
                {
                    centroids.Add(new Centroid());
                }

                // main loop
                for (int i = 0; i < iterations; i++)
                {
                    // clear point list for each centroid
                    centroids.ForEach(x => x.ClearPointList());

                    // store old centroids
                    List<List<double>> oldCentroidsCoordinates = centroids.ConvertAll(x => x.coordinates);

                    // assign points to centroid
                    for (int p = 0; p < points.Count; p++)
                    {
                        Tuple<double, int> smallestDistance = new Tuple<double, int>(double.MaxValue, 0);
                        for (int c = 0; c < centroids.Count; c++)
                        {
                            // calculate distance between point and centroid
                            double distance = similarity.Calculate(points[p].purchases, centroids[c].Coordinates());
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
                    if (HaveCentroidsStoppedMoving(oldCentroidsCoordinates))
                    {
                        actualIterations = i + 1;
                        break;
                    }
                }

                // store the centroids and sse (if the sse is lower)
                double sse = SSE();
                if (bestValues == null || sse < bestValues.Item2)
                {
                    bestValues = new Tuple<List<Centroid>, double>(centroids.ConvertAll(x => x.DeepCopy()), sse);
                }

                centroids.Clear();
            }
        }

        private bool HaveCentroidsStoppedMoving(List<List<double>> oldCentroidsCoordinates)
        {
            for (int i = 0; i < centroids.Count; i++)
            {
                if (!centroids[i].coordinates.SequenceEqual(oldCentroidsCoordinates[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private double SSE()
        {
            double sse = 0.0;
            for (int i = 0; i < centroids.Count; i++)
            {
                sse += centroids[i].CalculateSSE(similarity);
            }

            return sse;
        }

        private Dictionary<int, Dictionary<int, double>> CalculateDistanceMatrix()
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
                    double distance = similarity.Calculate(points[i].purchases, points[j].purchases.Select(x => (double)x).ToList());

                    if (distanceMatrix.ContainsKey(i))
                    {
                        distanceMatrix[i].Add(j, distance);
                    }
                    else
                    {
                        distanceMatrix.Add(i, new Dictionary<int, double>() { { j, distance } });
                    }
                }
            }

            return distanceMatrix;
        }

        public void PrintResults()
        {
            List<Centroid> bestCentroids = bestValues.Item1;
            double sse = bestValues.Item2;

            Console.WriteLine("KMeans ran " + iterations + " times");
            Console.WriteLine("With value for k: " + k);
            Console.WriteLine("Best value for the SSE: " + sse);
            Console.WriteLine();

            for (int x = 0; x < bestCentroids.Count; x++)
            {
                Console.WriteLine("Centroid " + (x + 1) + " has " + bestCentroids[x].points.Count + " points");
                var purchasesWithinCentroid = bestCentroids[x].GeneratePurchases();
                Dictionary<int, int> items = new Dictionary<int, int>();
                for (int i = 0; i < purchasesWithinCentroid.Count; i++)
                {
                    if (items.ContainsKey(purchasesWithinCentroid[i].offer))
                    {
                        items[purchasesWithinCentroid[i].offer]++;
                    }
                    else
                    {
                        items.Add(purchasesWithinCentroid[i].offer, 1);
                    }
                }
                var sortedItems = items.OrderByDescending(item => item.Value);

                foreach (var item in sortedItems)
                {
                    Console.WriteLine("offer " + item.Key + " has been purchased by " + item.Value + " people");
                }

                Console.WriteLine();
            }
        }
    }
}
