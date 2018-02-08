using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class ButterflyParameter : AbstractModel
    {
        public int ExperimentId { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string Side { get; set; }
        public double Value { get; set; }

        public ButterflyParameter(string name, string unit,string side, double value, StudyHeader experiment)
        {
            Title = name;
            Unit = unit;
            Value = value;
            Side = side;
            ExperimentId = experiment.Id;
            PatientId = experiment.Person.Id;
            FillExperimentData(experiment);
        }
    }
}
