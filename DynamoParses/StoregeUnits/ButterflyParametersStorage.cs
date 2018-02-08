using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    class ButterflyParametersStorage : AbstractStorage
    {
        public ButterflyParametersStorage() : base(){ }

        public List<ButterflyParameter> ParseElements(StudyHeader experiment)
        {
            Dictionary<string, string> parsedStrings = new Dictionary<string, string>();
            string[] array;
            double value;
            List<ButterflyParameter> paramameters = new List<ButterflyParameter>();
            foreach (string element in _elements)
            {
                parsedStrings = _getValueDict(element);
                if (parsedStrings["Unit"] == "left" || parsedStrings["Unit"] == "right")
                {
                    parsedStrings["Side"] = parsedStrings["Unit"];
                    parsedStrings["Unit"] = "NA";
                }
                array = parsedStrings["RemainingValues"].Split('\t');
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array[i].Replace(',', '.');
                }
                value = Convert.ToDouble(array[0]);

                paramameters.Add(
                    new ButterflyParameter(
                        parsedStrings["Title"],
                        parsedStrings["Unit"],
                        parsedStrings["Side"],
                        value,
                        experiment
                        ));
            }
            _elements = new List<string>();
            return paramameters;
        }
        override protected bool _validateLine(string element)
        {
            if (element.Split(',').Count() == 2
                ||
                element.Split(',').Count() == 3)
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, string> _getValueDict(string input)
        {
            bool hasSide;
            List<string> array = input.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (array.Count() > 2)
            {
                hasSide = true;
            }
            else
            {
                hasSide = false;
            }
            Dictionary<string, string> parameterValues = new Dictionary<string, string>();
            parameterValues["Title"] = array[0].Trim();
            array.RemoveAt(0);
            if (hasSide)
            {
                parameterValues["Unit"] = array[0].Trim();
                array.RemoveAt(0);
                parameterValues["Side"] = array[0].Split('\t')[0].Trim();
                array[0] = array[0].Split('\t')[1].Trim();
            }
            else
            {
                parameterValues["Side"] = "NA";
                parameterValues["Unit"] = array[0].Split('\t')[0].Trim();
                array[0] = array[0].Split('\t')[1].Trim();
            }
            parameterValues["RemainingValues"] = string.Join(",", array);

            return parameterValues;
        }
    }
}
