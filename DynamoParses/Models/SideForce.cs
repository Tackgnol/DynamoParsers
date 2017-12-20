using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class SideForce
    {
        public int PatientId { get; set; }
        public int ExperimentId { get; set; }
        public string Side { get; set; }
        public string BodyPart { get; set; }
        public double Time { get; set; }
        public double Value { get; set; }


        public SideForce(string side, string bodyPart, double time, double value, Header experiment)
        {
            Side = side;
            BodyPart = bodyPart;
            Time = time;
            Value = value;
            PatientId = experiment.PersonId;
            ExperimentId = experiment.Id;
        }
    }
}
