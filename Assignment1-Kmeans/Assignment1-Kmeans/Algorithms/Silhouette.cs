﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Assignment1_Kmeans.Utils;

namespace Assignment1_Kmeans.Algorithms
{
    class Silhouette
    {
        List<Point> points; 
        ISimilarity similarity;

        public Silhouette() {
            points = Parser.Parse(';', "wineKMCWithNames.csv");
            similarity = new Euclidean();
        }

        public void Run()
        {
            Dictionary<int, Dictionary<int, double>> distanceMatrix = CalculateDistanceMatrix();

            for (int k = 3; k < 6; k++)
            {
                KMeans kMeans = new KMeans(k);
                kMeans.Main();
                List<Centroid> centroids = kMeans.bestValues.Item1;
                List<Tuple<int, Point>> pointsWithCentroid = new List<Tuple<int, Point>>();
                List<int> totalPointsPerCluster = new List<int>();
                
                for (int i = 0; i < centroids.Count; i++)
                {
                    totalPointsPerCluster.Add(centroids[i].points.Count);
                    for (int j = 0; j < centroids[i].points.Count; j++)
                    {
                        pointsWithCentroid.Add(new Tuple<int, Point>(i, centroids[i].points[j]));
                    }
                }

                double silhouette = 0.0;
                for (int i = 0; i < pointsWithCentroid.Count; i++)
                {
                    double myCluster = 0.0;
                    double nearestCluster = double.MaxValue;
                    double averageDistance = 0.0;
                    for (int j = 0; j < pointsWithCentroid.Count; j++)
                    {
                        // retrieve the distance from the distance matrix
                        if (pointsWithCentroid[i].Item2.id < pointsWithCentroid[j].Item2.id)
                        {
                            averageDistance += distanceMatrix[pointsWithCentroid[i].Item2.id][pointsWithCentroid[j].Item2.id];
                        } else
                        {
                            averageDistance += distanceMatrix[pointsWithCentroid[j].Item2.id][pointsWithCentroid[i].Item2.id];
                        }

                        // check whether we've reached the end of the points within a cluster
                        if (j + 1 == pointsWithCentroid.Count || pointsWithCentroid[j].Item1 != pointsWithCentroid[j + 1].Item1)
                        {
                            averageDistance /= totalPointsPerCluster[pointsWithCentroid[j].Item1];

                            // check if we're dealing with points from the centroid the point belongs to
                            if (pointsWithCentroid[i].Item1 == pointsWithCentroid[j].Item1)
                            {
                                myCluster = averageDistance;
                                averageDistance = 0;
                                continue;
                            }

                            // check if the distance to a different cluster is smaller
                            if (averageDistance < nearestCluster)
                            {
                                nearestCluster = averageDistance;
                                averageDistance = 0;
                            }
                        }
                    }

                    silhouette += (nearestCluster - myCluster) / Math.Max(nearestCluster, myCluster);
                }

                silhouette /= pointsWithCentroid.Count;
                Console.WriteLine("Silhouette for value k(" + k + "): " +silhouette);
            }
        }

        private Dictionary<int, Dictionary<int, double>> CalculateDistanceMatrix()
        {
            // create a triangle dictionary -> distance matrix
            Dictionary<int, Dictionary<int, double>> distanceMatrix = new Dictionary<int, Dictionary<int, double>>();

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    if (points[j].id < points[i].id)
                    {
                        continue;
                    }
                    double distance = similarity.Calculate(points[i].purchases, points[j].purchases.Select(x => (double)x).ToList());

                    if (distanceMatrix.ContainsKey(points[i].id))
                    {
                        distanceMatrix[points[i].id].Add(points[j].id, distance);
                    }
                    else
                    {
                        distanceMatrix.Add(points[i].id, new Dictionary<int, double>() { { points[j].id, distance } });
                    }
                }
            }

            return distanceMatrix;
        }
    }
}
