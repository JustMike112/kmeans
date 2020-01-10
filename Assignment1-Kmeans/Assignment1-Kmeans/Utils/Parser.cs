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
                        points.Add(new Point());
                    }

                    //points[lineNumber - 1].AddPoint(column == "1" ? 1 : 0);
                    
                    item++;
                }
            }
            //var result = File.ReadAllLines(path).Select(
            //        line => line.Split(delimiter)
            //                .Select(float.Parse).ToList())
            //        .ToList();

            // Loop through all rows and columns
            //for (var i = 0; i < result.Count; i++)
            //{
            //    for (var j = 0; j < result[i].Count; j++)
            //    {
            //        if (vectors.ElementAtOrDefault(j) == null)
            //            vectors.Add(new Vector());

            //        vectors[j].AddPoint(result[i][j]);
            //    }
            //}

            return points;
        }
    }
}
