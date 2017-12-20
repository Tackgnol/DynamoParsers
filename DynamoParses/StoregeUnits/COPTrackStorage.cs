using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    class COPTrackStorage : AbstractStorage
    {
        public COPTrackStorage() : base() { }

        public List<COPTrack> ParseElements(Header expriment)
        {
            List<COPTrack> parsedCOPTracks = new List<COPTrack>();
            Dictionary<string, string> valueDictionary = new Dictionary<string, string>();
            foreach (string element in _elements)
            {
                valueDictionary = _getValueDict(element);
                string[] valueArray = valueDictionary["Values"].Split('\t');
                for (int i = 0; i < valueArray.Length; i++)
                {
                    valueArray[i] = valueArray[i].Trim();
                    valueArray[i] = valueArray[i].Replace(',', '.');
                }
                List<double> valueList = valueArray.Select(double.Parse).ToList();
                parsedCOPTracks.Add(
                        new COPTrack(
                            valueDictionary["Side"],
                            valueList[0],
                            valueList[1],
                            valueList[2],
                            expriment
                        )
                    );
            }
            _elements = new List<string>();
            return parsedCOPTracks;
        }

        override protected bool _validateLine(string element)
        {
            var array = element.Split(new[] { " ", "	" }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Count() == 4)
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, string> _getValueDict(string input)
        {
            Dictionary<string, string> valueDictionary = new Dictionary<string, string>();

            List<string> array = input.Split(',').ToList();
            valueDictionary["Side"] = array[0];
            array.RemoveAt(0);
            valueDictionary["Values"] = string.Join(",", array);

            return valueDictionary;
        }
    }
}
