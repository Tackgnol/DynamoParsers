using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    class MaxForceStorage : AbstractStorage
    {
        public MaxForceStorage() : base(){ }

        public List<MaxForce> ParseElements(StudyHeader experiment)
        {

            Dictionary<string, string> parsedStrings = new Dictionary<string, string>();
            string[] array;
            double X, Y;
            List<MaxForce> paramameters = new List<MaxForce>();
            foreach (string element in _elements)
            {
                parsedStrings = _getValueDict(element);
                double value = Convert.ToDouble(parsedStrings["RemainingValues"].Replace(',', '.'), CultureInfo.InvariantCulture);
                paramameters.Add(
                    new MaxForce(
                        parsedStrings["Title"],
                        parsedStrings["Unit"],
                        parsedStrings["Side"],
                        value,
                        experiment
                        )
                    );
            }
            _elements = new List<string>();
            return paramameters;

        }

        override protected bool _validateLine(string element)
        {
            string[] array = element.Split('	');
            if (array.Count() == 3)
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, string> _getValueDict(string input)
        {
            bool hasSide;
            List<string> array = input.Split(new[] { "	" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Dictionary<string, string> parameterValues = new Dictionary<string, string>();
            parameterValues["Side"] = array[0].Split(',')[0];
            parameterValues["Title"] = array[0].Split(',')[3];
            array.RemoveAt(0);
            parameterValues["Unit"] = array[0];
            array.RemoveAt(0);

            parameterValues["RemainingValues"] = array[0];

            return parameterValues;
        }

    }
}

