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
            KMeans kMeans = new KMeans();
            kMeans.Main();
            kMeans.PrintResults();

            Silhouette silhouette = new Silhouette();
            silhouette.Run();

            Console.SetCursorPosition(0, 0);
            Console.ReadLine();
        }
    }
}
