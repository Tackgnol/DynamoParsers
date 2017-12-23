using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    class MaxForce
    {
        public int ExperimentId { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string Side { get; set; }

        public double Value { get; set; }

        public MaxForce(string title, string unit, string side, double value, Header experiment)
        {
            Title = title;
            Unit = unit;
            Side = side;
            Value = value;
            ExperimentId = experiment.Id;
            PatientId = experiment.Person.Id;
        }
    }
}
