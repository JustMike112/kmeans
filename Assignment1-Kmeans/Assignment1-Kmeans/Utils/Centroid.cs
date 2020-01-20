using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    class Centroid
    {
        private int number;
        private List<double> coordinates;
        private List<Point> points = new List<Point>();

        public Centroid(int number)
        {
            this.number = number;
        }

        public List<double> Coordinates()
        {
            return coordinates;
        }

        private void Initialize()
        {
            // Create starting coordinates
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
        }

        public double CalculateSSE()
        {
            // calculate the SSE based on the points within the centroid
            return 0.0;
        }

    }
}
