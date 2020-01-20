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
            List<CustomerData> customerItems = new List<CustomerData>();
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

                    if (column == "1")
                    {
                        points[lineNumber - 1].AddSales(1);
                        customerItems.Add(new CustomerData(lineNumber, item + 1));
                    }
                    else
                    {
                        points[lineNumber - 1].AddSales(0);
                    }


                    item++;
                }
            }

            return points;
        }
    }
}
