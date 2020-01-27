﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Assignment1_Kmeans.Algorithms;

namespace Assignment1_Kmeans.Utils
{
    class Centroid
    {
        public int number;
        private Random random = new Random();
        public List<double> coordinates = new List<double>();
        public List<Point> points = new List<Point>();

        public Centroid()
        {
            Initialize();
        }

        public Centroid(int number)
        {
            this.number = number;
            Initialize();
        }

        public List<double> Coordinates()
        {
            return coordinates;
        }

        private void Initialize()
        {
            // Create starting coordinates
            for (int i = 0; i < 32; i++)
            {
                coordinates.Add(random.NextDouble());
            }
        }

        public void AddPoint(Point p)
        {
            points.Add(p);
        }

        public void ClearPointList()
        {
            points.Clear();
        }

        public void CalculateCentroidPosition()
        {
            // calculate the new coordinates based on the points within the centroid
            List<double> newPosition = new List<double>();
            for (int i = 0; i < coordinates.Count; i++)
            {
                newPosition.Add(0.0);
            }

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < newPosition.Count; j++)
                {
                    newPosition[j] += points[i].customerSales[j];
                }
            }
            
            for (int i = 0; i < newPosition.Count; i++)
            {
                newPosition[i] /= newPosition.Count;
            }

            coordinates = newPosition;
        }

        public List<CustomerData> GeneratePurchases()
        {
            List<CustomerData> purchases = new List<CustomerData>();

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points[i].customerSales.Count; j++)
                {
                    if (points[i].customerSales[j] == 1)
                    {
                        purchases.Add(new CustomerData(points[i].customerID, j + 1, points[i].name));
                    }
                }
            }
            return purchases;
        }

        // calculate the SSE based on the points within the centroid
        public double CalculateSSE(ISimilarity similarity)
        {
            double SSE = 0.0;

            for (int i = 0; i < points.Count; i++)
            {
                SSE += Math.Pow(similarity.Calculate(points[i].customerSales, coordinates), 2);
            }

            return SSE;
        }

        public Centroid DeepCopy()
        {
            Centroid centroid = new Centroid();
            centroid.points = this.points;
            centroid.coordinates = this.coordinates;
            centroid.number = this.number;

            return centroid;
        }

    }
}
