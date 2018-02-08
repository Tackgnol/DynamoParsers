using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class ContactTime : AbstractModel
    {
        public int PatientId { get; set; }
        public int ExperimentId { get; set; }
        public string Bodypart { get; set; }
        public string Side { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }

        public ContactTime(string bodypart, string side, double t1, double t2, StudyHeader experiment)
        {
            Bodypart = bodypart;
            Side = side;
            T1 = t1;
            T2 = t2;
            PatientId = experiment.PersonId;
            ExperimentId = experiment.Id;
            FillExperimentData(experiment);
        }
    }
}
