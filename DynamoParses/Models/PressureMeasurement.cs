using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class PressureMeasurement
    {
        public int ExperimentId { get; set; }
        public int PatientId { get; set; }
        public string BodyPart { get; set; }
        public double Force { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public PressureMeasurement(string bodyPart, double f, double x, double y, Header experiment)
        {
            BodyPart = bodyPart;
            Force = f;
            X = x;
            Y = y;
            ExperimentId = experiment.Id;
            PatientId = experiment.Person.Id;
        }
    }
}
