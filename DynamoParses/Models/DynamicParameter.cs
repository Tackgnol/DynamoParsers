using DynamoParses.StoregeUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class DynamicParameter 
    {
        public int ExperimentId { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string Side { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public DynamicParameter(string title, string unit, string side, double x, double y, Header experiment)
        {
            Title = title;
            Unit = unit;
            Side = side;
            X = x;
            Y = y;
            ExperimentId = experiment.Id;
            PatientId = experiment.Person.Id;
        }
    }
}
