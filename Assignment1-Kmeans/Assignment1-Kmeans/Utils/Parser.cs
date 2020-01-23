using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment1_Kmeans.Utils
{
    static class Parser
    {
        public static List<Point> Parse(char delimiter, string path)
        {
            var result = File.ReadAllLines(path);
            List<Point> points = new List<Point>();
            
            foreach (var row in result)
            {
                var x = row.Split(delimiter);
                var item = 0;
                foreach (var column in x)
                {
                    if (item == 0)
                    {
                        item++;
                        continue;
                    }

                    if (points.ElementAtOrDefault(item - 1) == null)
                    {
                        points.Add(new Point(item));
                    }

                    if (column == "1")
                    {
                        points[item - 1].AddSales(1);
                    }
                    else
                    {
                        points[item - 1].AddSales(0);
                    }


                    item++;
                }
            }

            return points;
        }
    }
}
