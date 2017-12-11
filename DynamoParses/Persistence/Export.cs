using ClosedXML.Excel;
using DynamoParses.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Persistence
{
    public class Export
    {
        private XLWorkbook wb;
        public Export()
        {
            wb = new XLWorkbook();
        }
        public void DumpValues<T>(string sheetName, List<T> valueList)
        {
            List<string> propertyList = typeof(T).GetProperties().Select(f => f.Name).ToList();
            var newWS = wb.Worksheets.Add(sheetName);
            for (int i = 0; i < propertyList.Count(); i++)
            {
                newWS.Cell(1, i+1).Value = propertyList[i];
            }
            newWS.Cell(2, 1).InsertData(valueList);
        }
        public void Save(string directory)
        {
            wb.SaveAs(directory);
        }
    }
}
