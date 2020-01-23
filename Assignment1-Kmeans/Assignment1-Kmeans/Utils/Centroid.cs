using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class Centroid
    {
        private int number;
        private Random random = new Random();
        public List<double> coordinates = new List<double>();
        public List<Point> points = new List<Point>();

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

        public double CalculateSSE()
        {
            // calculate the SSE based on the points within the centroid
            return 0.0;
        }

    }
}
