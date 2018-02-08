using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class StudyHeader
    {
        private static int m_Counter = 0;
        public int Id { get; set; }
        public Patient Person { get; set; }
        public int PersonId
        {
            get
            {
                return Person.Id;
            }
        }
        public string NiceStudyName
        {
            get
            {
                try
                {
                    string niceName = "";
                    niceName += ((bool)Eyes ? "Eyes open" : "Eyes Closed");
                    niceName += ((bool)Shoes ? " With shoes" : "Without shoes");
                    niceName += " Attempt: " + TrialNo;
                    return niceName;
                }
                catch
                {
                    return "";
                }
            }
        }
        public DateTime Date { get; set; }
        public string ExperimentTitle { get; set; }
        public bool? Eyes { get; set; }
        public bool? Shoes { get; set; }
        public string TrialNo { get; set; }
        public string RepeatNo { get; set; }
        private string[] _fileNameArray;
        public StudyHeader(Patient person, DateTime date, string title, string[] fileNameArray)
        {
            // ToDo: Implement Oczy, Buty & numer from filename
            Id = System.Threading.Interlocked.Increment(ref m_Counter);
            Person = person;
            Date = date;
            ExperimentTitle = title;
            _fileNameArray = fileNameArray;
        }
        public void TryParseFileNameArray()
        {
            try
            {

                if (_fileNameArray[2] == "oo")
                {
                    Eyes = true;
                }
                else if (_fileNameArray[2] == "oz")
                {
                    Eyes = false;
                }
                if (_fileNameArray[3] == "b")
                {
                    Shoes = true;
                }
                else if (_fileNameArray[3] == "bb")
                {
                    Shoes = false;
                }
                TrialNo = _fileNameArray[4];
                RepeatNo = _fileNameArray[5];

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + _fileNameArray.ToString());
            }
        }
    }

}
