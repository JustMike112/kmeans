using System;
using System.IO;
using System.Linq;
using Assignment1_Kmeans.Utils;
using Assignment1_Kmeans.Algorithms;
using System.Collections.Generic;

namespace Assignment1_Kmeans
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result2 = File.ReadAllLines("WineKMC.csv");
            //var lineNumber = 0;
            //foreach (var line in result2)
            //{
            //    var x = line.Split(";");
            //    lineNumber++;
            //    var item = 0;
            //    var count = 0;
            //    foreach (var column in x)
            //    {
            //        if (item == 0)
            //        {
            //            item++;
            //            continue;
            //        }
            //        count++;
            //        if (column == "1")
            //        {
            //            Console.Write(column);
            //        } else { 
            //            // make it 0
            //            Console.Write("0");
            //        }
            //        item++;
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine(count);
            //}

            List<Point> points = Parser.Parse(';', "wineKMC.csv");
            Centroid c = new Centroid(1);
            KMeans kMeans = new KMeans();
            kMeans.Main(points);
            ISimilarity similarity = new Euclidean();
            var sim = similarity.Calculate(points[0].customerSales, points[1].customerSales.Select(x => (double)x).ToList());
            Console.WriteLine(sim);

            // create a triangle dictionary -> distance matrix
            Dictionary<string, double> distanceMatrix = new Dictionary<string, double>();

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    if (distanceMatrix.ContainsKey(j + " " + i))
                    {
                        continue;
                    }
                    double distance = similarity.Calculate(points[i].customerSales, points[j].customerSales.Select(x => (double)x).ToList());
                    distanceMatrix[i + " " + j] = distance;
                }
                Console.WriteLine(i);
            }

            if (distanceMatrix.ContainsKey(0 + " " + 99))
            {
                Console.Write('x');
                Console.WriteLine(distanceMatrix[0 + " " + 99]);
            }
            if (distanceMatrix.ContainsKey(44 + " " + 44))
            {
                Console.Write('y');
                Console.WriteLine(distanceMatrix[44 + " " + 44]);
            }


            Console.ReadLine();
        }
    }
}
