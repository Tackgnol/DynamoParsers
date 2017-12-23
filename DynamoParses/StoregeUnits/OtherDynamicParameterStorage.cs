using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    class OtherDynamicParameterStorage : AbstractStorage
    {
        public Dictionary<string, string> OtherParameterHeaders = new Dictionary<string, string>()
            {
                { "Contact time, sec", "Contact time, sec"},
                { "Contact time % of stance time", "Contact time, % of stance time" },
                { "Max force, N", "Max force, N" },
                { "Max force time, sec", "Max force time, sec" },
                { "Max pressure, N/cm^2", "Max pressure, N/cm^2" },
                { "Max force time % of stance time", "Max force time, % of stance time" }
            };

        public OtherDynamicParameterStorage() : base() { }
        public List<OtherDynamicParameter> ParseElements(Header experiment)
        {
            List<OtherDynamicParameter> otherDynamicParamaters = new List<OtherDynamicParameter>();
            List<string> array = new List<string>();
            double X, Y;
            foreach (string element in _elements)
            {
                Dictionary<string, string> parsedStrings = _getValueDict(element);
                array = parsedStrings["Values"].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int i = 0; i < array.Count; i++)
                {
                    array[i] = array[i].Replace(',', '.');
                }
                X = Convert.ToDouble(array[0]);
                Y = Convert.ToDouble(array[1]);

                otherDynamicParamaters.Add(
                    new OtherDynamicParameter(
                        parsedStrings["Title"],
                        parsedStrings["Unit"],
                        parsedStrings["Side"],
                        parsedStrings["BodyPart"],
                        X, Y,
                        experiment
                    )
                );
            }
            return otherDynamicParamaters;
        }

        override protected bool _validateLine(string element)
        {
            string[] array = element.Split(',');
            if (array.Count() == 7 || array.Count() == 8)
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, string> _getValueDict(string input)
        {
            List<string> array = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, string> parsedStrings = new Dictionary<string, string>();
            parsedStrings["Title"] = array[0];
            array.RemoveAt(0);
            parsedStrings["Unit"] = array[0];
            array.RemoveAt(0);
            if (array.Count == 2)
            {
                parsedStrings["BodyPart"] = array[0];
                array.RemoveAt(0);
            } else {
                parsedStrings["BodyPart"] = null;
            }

            List<string> subArray = array[0].Split(new string[] { "	", "	" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            parsedStrings["Side"] = subArray[0];
            subArray.RemoveAt(0);
            parsedStrings["Values"] = string.Join(", ", subArray);
            return parsedStrings;
        }

    }
}

