using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class COPTrack
    {
        public int PatientId { get; set; }
        public int ExperimentId { get; set; }
        public string Side { get; set; }
        public double Force { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public COPTrack(string side, double force, double x, double y, Header experiment)
        {
            Side = side;
            Force = force;
            X = x;
            Y = y;
            PatientId = experiment.PersonId;
            ExperimentId = experiment.Id;
        }

    }
}
