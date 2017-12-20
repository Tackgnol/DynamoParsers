using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    class StaticParameterStorage : AbstractStorage
    {
        public StaticParameterStorage() : base() { }
        override protected bool _validateLine(string element)
        {
            string[] array = element.Split(',');
            if (array.Count() == 3)
            {
                return true;
            }
            return false;
        }

        public List<StaticParameter> ParseElements(Header experiment)
        {
            List<StaticParameter> parsedParameters = new List<StaticParameter>();
            Dictionary<string, string> valueDictionary = new Dictionary<string, string>();

            foreach (string element in _elements)
            {
                valueDictionary = _getValueDict(element);
                string[] valueArray = valueDictionary["Values"].Split(new []{ '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
                valueArray[1] = valueArray[1].Replace(',', '.');
                string side = null;
                if (valueArray.Length == 3)
                {
                    side = valueArray[2];
                }

                parsedParameters.Add(
                        new StaticParameter(
                                valueDictionary["Title"],
                                valueArray[0],
                                side,
                                Convert.ToDouble(valueArray[1]),
                                experiment
                            )   
                    );
            }
            _elements = new List<string>();
            return parsedParameters;
        }
        private Dictionary<string, string> _getValueDict(string input)
        {
            Dictionary<string, string> valueDictionary = new Dictionary<string, string>();

            List<string> array = input.Split(',').ToList();
            valueDictionary["Title"] = array[0];
            array.RemoveAt(0);

            valueDictionary["Values"] = string.Join(",", array);

            return valueDictionary;
        }
    }
}
