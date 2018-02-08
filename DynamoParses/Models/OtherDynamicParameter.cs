using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    class OtherDynamicParameter : AbstractModel
    {
        public int ExperimentId { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string Side { get; set; }
        public string BodyPart { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public OtherDynamicParameter(string title, string unit, string side,string bodyPart, double x, double y, StudyHeader experiment)
        {
            Title = title;
            Unit = unit;
            Side = side;
            BodyPart = bodyPart;
            X = x;
            Y = y;
            ExperimentId = experiment.Id;
            PatientId = experiment.Person.Id;
            FillExperimentData(experiment);
        }
    }
}

