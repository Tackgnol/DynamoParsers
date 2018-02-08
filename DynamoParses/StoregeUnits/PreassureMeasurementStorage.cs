using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    public class PreassureMeasurementStorage : AbstractStorage
    {
        public PreassureMeasurementStorage() : base() { }

        public List<PressureMeasurement> ParseElements(StudyHeader experiment)
        {
            string foot;
            double force, X, Y;
            string tempString;
            string[] array; 
            List<PressureMeasurement> measurements = new List<PressureMeasurement>();
            foreach (string element in _elements)
            {
                foot = _getFoot(element);
                tempString = _dumpFoot(element);
                array = tempString.Split('\t');
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == " - ")
                    {
                        array[i] = "0";
                    }
                    array[i] = array[i].Replace(',', '.');
                }

                force = Convert.ToDouble(array[0], CultureInfo.InvariantCulture);
                X = Convert.ToDouble(array[1], CultureInfo.InvariantCulture);
                Y = Convert.ToDouble(array[2], CultureInfo.InvariantCulture);
                measurements.Add(new PressureMeasurement(foot, force, X, Y, experiment));
            }
            _elements = new List<string>();
            return measurements;
        }

        override protected bool _validateLine(string element)
        {
            double isNum;
            var array = element.Split(new[] { " ", "	" }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Count() == 4)
            {
                if (double.TryParse(array[1],out isNum))
                {
                    return true;
                }
            }
            return false;
        }
        private string _getFoot(string input)
        {
            return input.Split(',')[0];
        }
        private string _dumpFoot(string input)
        {
            List<string> measurementArray = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            measurementArray.RemoveAt(0);
            return string.Join(",", measurementArray);
        }
    }
}
