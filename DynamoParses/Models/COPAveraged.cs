using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class COPAveraged : AbstractModel
    {
        public int ExperimentId { get; set; }
        public int PatientId { get; set; }
        public string Side { get; set; }
        public string BodyPart { get; set; }
        public string Unit { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public COPAveraged(string side, string bodyPart, string unit, double x, double y,  StudyHeader experiment)
        {
            Side = side;
            BodyPart = bodyPart;
            Unit = unit;
            X = x;
            Y = y;
            PatientId = experiment.PersonId;
            ExperimentId = experiment.Id;
            FillExperimentData(experiment);
        }

    }
}
