using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    public class ForceOverlayStorage : AbstractStorage
    {
        public ForceOverlayStorage() : base(){ }

        public List<ForceOverlay> ParseElements(StudyHeader experiment)
        {
            List<ForceOverlay> forceOverlays = new List<ForceOverlay>();
            Dictionary<string, string> parsedValues = new Dictionary<string, string>();
            string[] array;
            foreach (string element in _elements)
            {
                parsedValues = _getValueDict(element);
                array = parsedValues["Values"].Split('\t');
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array[i].Trim();
                    array[i] = array[i].Replace(',', '.');
                }
                forceOverlays.Add(
                    new ForceOverlay(
                        parsedValues["Title"],
                        parsedValues["Side"],
                        parsedValues["BodyPart"],
                        Convert.ToInt32(array[0], CultureInfo.InvariantCulture),
                        Convert.ToDouble(array[1], CultureInfo.InvariantCulture),
                        experiment
                        )
                    );
            }
            _elements = new List<string>();
            return forceOverlays;
        }
        override protected bool _validateLine(string element)
        {
            var array = element.Split(new[] { " ", "	" }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Count() == 6)
            {
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
            parsedValues["BodyPart"] = array[0].Trim();
            array.RemoveAt(0);
            parsedValues["Values"] = string.Join(",", array);
            return parsedValues;
        }
    }
}
