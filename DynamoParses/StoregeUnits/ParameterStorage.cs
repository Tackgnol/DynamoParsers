using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    public class ParameterStorage : AbstractStorage
    {
        public ParameterStorage() : base(){ }
        public List<DynamicParameter> ParseElements(StudyHeader experiment)
        {

            Dictionary<string, string> parsedStrings = new Dictionary<string, string>();
            string[] array;
            double X, Y;
            List<DynamicParameter> paramameters = new List<DynamicParameter>();
            foreach (string element in _elements)
            {
                parsedStrings = _getValueDict(element);
                array = parsedStrings["RemainingValues"].Split('\t');
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array[i].Replace(',', '.');
                }
                X = Convert.ToDouble(array[0], CultureInfo.InvariantCulture);
                Y = Convert.ToDouble(array[1], CultureInfo.InvariantCulture);
                paramameters.Add(
                    new DynamicParameter(
                        parsedStrings["Title"],
                        parsedStrings["Unit"],
                        parsedStrings["Side"],
                        X, Y,
                        experiment
                        ));
            }
            _elements = new List<string>();
            return paramameters;

        }

        override protected bool _validateLine(string element)
        {
            string[] array = element.Split(',');
            if (array.Count() == 4
                ||
                array.Count() == 5)
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, string> _getValueDict(string input)
        {
            bool hasSide; 
            List<string> array = input.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (array.Count()>4)
            {
                hasSide = true;
            } else {
                hasSide = false;
            }
            Dictionary<string, string> parameterValues = new Dictionary<string, string>();
            parameterValues["Title"] = array[0];
            array.RemoveAt(0);
            if (hasSide)
            {
                parameterValues["Unit"] = array[0];
                array.RemoveAt(0);
                parameterValues["Side"] = array[0].Split('\t')[0];
                array[0] = array[0].Split('\t')[1];
            } else {
                parameterValues["Side"] = "NA";
                parameterValues["Unit"] = array[0].Split('\t')[0];
                array[0] = array[0].Split('\t')[1];
            }
            parameterValues["RemainingValues"] = string.Join(",", array);

            return parameterValues;
        }

    }
}
