using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    public class OtherPreasureStorage : AbstractStorage
    {
        public OtherPreasureStorage() : base(){ }

        public List<OtherPreassureMeasurement> ParseElements(StudyHeader experiment)
        {
            string[] valueArray;
            double? sd;
            Dictionary<string, string> parsedValues = new Dictionary<string, string>();
            List<OtherPreassureMeasurement> otherPreassures = new List<OtherPreassureMeasurement>();
            foreach (string element in _elements)
            {
                parsedValues = _getValueDict(element);
                valueArray = parsedValues["Values"].Split('\t');
                for (int i = 0; i < valueArray.Length; i++)
                {
                    valueArray[i] = valueArray[i].Trim();
                    valueArray[i] = valueArray[i].Replace(',', '.');
                }
                if (valueArray.Count() == 3)
                {
                    sd = Convert.ToDouble(valueArray[2], CultureInfo.InvariantCulture);
                } else {
                    sd = null;
                }
                otherPreassures.Add(
                    new OtherPreassureMeasurement(
                            parsedValues["Side"],
                            parsedValues["Title"],
                            parsedValues["Measurement"],
                            Convert.ToInt32(valueArray[0], CultureInfo.InvariantCulture),
                            Convert.ToDouble(valueArray[1], CultureInfo.InvariantCulture),
                            sd, experiment
                        )
                    );
            }
            _elements = new List<string>();
            return otherPreassures;
        }

        override protected bool _validateLine(string element)
        {
            double isNum;
            var array = element.Split(new[] { " ", "	" }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Count() == 8 || array.Count() == 7)
            {
                if (double.TryParse(array[5], out isNum))
                    return true;
            }
            return false;
        }
        private Dictionary<string, string> _getValueDict(string input)
        {
            Dictionary<string, string> parsedValues = new Dictionary<string, string>();
            List<string> array = input.Split(',').ToList();
            parsedValues["Side"] = array[0].Trim();
            array.RemoveAt(0);
            parsedValues["Title"] = array[0].Trim();
            array.RemoveAt(0);
            parsedValues["Measurement"] = array[0].Trim();
            array.RemoveAt(0);
            parsedValues["Values"] = string.Join(",", array);
            return parsedValues;            
        }
    }
}
