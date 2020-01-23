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

            for (int i = 0; i < 10; i++)
            {
                c.AddPoint(points[i]);
            }
            c.CalculateCentroidPosition();

            for (int i = 0; i < c.Coordinates().Count; i++)
            {
                Console.Write(c.Coordinates()[i] + " ");
            }


            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points[i].customerSales.Count; j++)
                {
                    Console.WriteLine(j + ": " + points[i].customerSales[j]);
                }
                break;
            }
            
            Console.WriteLine(points[0].customerSales.Count);
            Console.ReadLine();
        }
    }
}
