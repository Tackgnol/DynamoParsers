using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    public class HeaderStorage : AbstractStorage
    {

        public HeaderStorage() : base() { }
        public string fileName { get; set; }
        override protected bool _validateLine(string element)
        {
            if (element.Length >= 1)
            {
                return true;
            }
            return false;
        }


        public StudyHeader ParseElements(PatientStorage patients)
        {
            string firstName, lastName, title, sex;
            Patient currentPatient;
            DateTime expirementDate;

            var dateLine = from header in _elements
                           where header.Contains("date")
                           select header;
            expirementDate = DateTime.ParseExact(
                dateLine.First().ToString().Split('\t', ' ')[1],
                "d/M/yyyy",
                CultureInfo.InvariantCulture
                );
            var patientLine = from header in _elements
                              where header.Contains("patient")
                              select header;
            var patientArray = patientLine.First().ToString().Split(new[] { " ", "	" }, StringSplitOptions.RemoveEmptyEntries);
            var tempArray = new List<string>(patientArray);
            tempArray.RemoveAt(0);
            sex = tempArray.Last();
            tempArray.RemoveAt(tempArray.Count-1);
            patientArray = tempArray.ToArray();
            var newString = string.Join("", patientArray);
            patientArray = newString.ToString().Split(',');
            firstName = patientArray[1];
            lastName = patientArray[0];

            currentPatient = patients.GetOrCreate(firstName, lastName, sex);

            var titleLine = from header in _elements
                            where header.Contains("record1")
                            select header;
            Match titleMatch = Regex.Match(titleLine.First().ToString(), "(?<=..-..-....)(.*)(?=../../....)");
            title = titleMatch.Groups[0].Value.Trim();
            _elements = new List<string>();
            var fileArray = fileName.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            return new StudyHeader(currentPatient, expirementDate, title, fileArray);

        }

    }
}
