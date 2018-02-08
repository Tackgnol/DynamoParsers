using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class ForceOverlay : AbstractModel
    {
        public int PatientId { get; set; }
        public int ExperimentId { get; set; }

        public string Title { get; set; }
        public string Side { get; set; }
        public string BodyPart { get; set; }
        public double Value { get; set; }
        public int Time { get; set; }

        public ForceOverlay(string title, string side, string bodyPart, int time, double value, StudyHeader experiment)
        {
            BodyPart = bodyPart;
            Side = side;
            Time = time;
            Title = title;
            Value = value;
            PatientId = experiment.Person.Id;
            ExperimentId = experiment.Id;
            FillExperimentData(experiment);
        }
    }
}
