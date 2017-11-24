using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DynamoParses.Parsers
{
    class Pressures
    {
        public PressureMeasurement parsePressures(string input)
        {
            string stringPattern = @"(\d+),(\d+)";
            double[] items = new double[3];
            int i=0;
            string matches = Regex.Matches(input, stringPattern).ToString();
            foreach (Match m in Regex.Matches(input, stringPattern))
            {
                items[i] = Convert.ToDouble(m.Value.Replace(',','.'));
                i++;

            }
            return new PressureMeasurement(items[0],
                items[1],
                items[2]);
        }
    }
}
