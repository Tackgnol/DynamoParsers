﻿using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    class SideForceStorage : AbstractStorage
    {
        public SideForceStorage() : base() { }



        override protected bool _validateLine(string element)
        {
            var array = element.Split(new[] { " ", "	" }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Count() == 4)
            {
                return true;
            }
            return false;
        }

        public List<SideForce> ParseElements(StudyHeader expriment)
        {
            List<SideForce> parsedSideForces =  new List<SideForce>();
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
                List<double> valueList = valueArray.Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToList();
                parsedSideForces.Add(
                        new SideForce(
                            valueDictionary["Side"],
                            valueDictionary["BodyPart"],
                            valueList[0],
                            valueList[1],
                            expriment
                        )
                    );
            }
            _elements = new List<string>();
            return parsedSideForces;
        }

        private Dictionary<string, string> _getValueDict(string input)
        {
            Dictionary<string, string> valueDictionary = new Dictionary<string, string>();

            List<string> array = input.Split(',').ToList();
            valueDictionary["Side"] = array[0];
            array.RemoveAt(0);
            valueDictionary["BodyPart"] = array[0];
            array.RemoveAt(0);

            valueDictionary["Values"] = string.Join(",", array);

            return valueDictionary;
        }

    }
}
