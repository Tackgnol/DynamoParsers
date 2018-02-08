using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class OtherPreassureMeasurement : AbstractModel
    {
        public int ExperimentId { get; set; }
        public int PatientId { get; set; }
        public string Bodypart { get; set; }
        public string Title { get; set; }
        public string Measurement { get; set; }
        public int Time { get; set; }
        public double Value { get; set; }
        public double? SD { get; set; }

        public OtherPreassureMeasurement(string bodypart, string title, string measurement, int time, double value, double? sd, StudyHeader experiment)
        {
            Bodypart = bodypart;
            Time = time;
            Value = value;
            SD = sd;
            Title = title;
            Measurement = measurement;
            ExperimentId = experiment.Id;
            PatientId = experiment.Person.Id;
            FillExperimentData(experiment);
        }
    }
}
