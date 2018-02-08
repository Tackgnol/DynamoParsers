using DynamoParses.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public abstract class AbstractModel
    {
        public DateTime Date { get; set; }
        public string ExperimentTitle { get; set; }
        public bool? Eyes { get; set; }
        public bool? Shoes { get; set; }
        public string TrialNo { get; set; }
        public string RepeatNo { get; set; }
        public string PatientName { get; set; }
        public string NiceStudyName { get; set; }


        protected void FillExperimentData(StudyHeader e)
        {
            Date = e.Date;
            ExperimentTitle = e.ExperimentTitle;
            Eyes = e.Eyes;
            Shoes = e.Shoes;
            TrialNo = e.TrialNo;
            RepeatNo = e.RepeatNo;
            PatientName = e.Person.FullName();
            NiceStudyName = e.NiceStudyName;
        }
    }
}
