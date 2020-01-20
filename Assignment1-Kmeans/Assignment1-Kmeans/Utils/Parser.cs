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
            var lineNumber = 0;
            
            foreach (var line in result)
            {
                var x = line.Split(delimiter);
                lineNumber++;
                var item = 0;
                foreach (var column in x)
                {
                    if (item == 0)
                    {
                        item++;
                        continue;
                    }

                    if (points.ElementAtOrDefault(lineNumber - 1) == null)
                    {
                        points.Add(new Point(lineNumber));
                    }

                    points[lineNumber - 1].AddSales(column == "1" ? 1 : 0);

                    item++;
                }
            }

            return points;
        }
    }
}
