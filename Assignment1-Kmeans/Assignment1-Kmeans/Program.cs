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
            KMeans kMeans = new KMeans();
            kMeans.Main(points);

            Console.ReadLine();
        }
    }
}
