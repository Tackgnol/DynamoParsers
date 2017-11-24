using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    class PressureMeasurement
    {
        public double Force { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public PressureMeasurement(double f, double x, double y)
        {
            Force = f;
            X = x;
            Y = y;
        }
    }
}
