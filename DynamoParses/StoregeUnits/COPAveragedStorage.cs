using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DynamoParses.StoregeUnits
{
    class COPAveragedStorage : AbstractStorage
    {
        public COPAveragedStorage() : base() { }

        public List<COPAveraged> ParseElements(Header experiment)
        {
            List<COPAveraged> COPAverages = new List<COPAveraged>();
            Dictionary<string, string> valueDictionary = new Dictionary<string, string>();
            foreach (string element in _elements)
            {
                valueDictionary = _getValueDict(element);
                string[] valuesArray = valueDictionary["Values"].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < valuesArray.Count(); i++)
                {
                    valuesArray[i] = valuesArray[i].Trim();
                    valuesArray[i] = valuesArray[i].Replace(',', '.');
                }

                COPAverages.Add(
                    new COPAveraged(
                        valueDictionary["Side"],
                        valueDictionary["BodyPart"],
                        valueDictionary["Unit"],
                        Convert.ToDouble(valuesArray[0]),
                        Convert.ToDouble(valuesArray[1]),
                        experiment
                        )
                    );
            }
            _elements = new List<string>();
            return COPAverages;
        }

        override protected bool _validateLine(string element)
        {
            if (element.Split(',').Count() == 5)
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, string> _getValueDict(string input)
        {
            Dictionary<string, string> valueDictionary = new Dictionary<string, string>();

            List<string> array = input.Split(',').ToList();
            valueDictionary["Side"] = array[0].Split(' ')[0];
            valueDictionary["BodyPart"] = array[0].Split(' ')[1];
            array.RemoveAt(0);
            valueDictionary["Unit"] = array[0].Split('=')[0].Trim();
            Match m = Regex.Match(input, @"\{([^)]*)\}");
            valueDictionary["Values"] = m.Groups[1].Value;

            return valueDictionary;
        }

    }
}
