
using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DynamoParses.Persistence
{
    public class Export
    {
        private ExcelPackage xlPackage;
        private FileInfo newFile;
        public Export(string file)
        {
            newFile = new FileInfo(file);
            xlPackage = new ExcelPackage(newFile);

        }
        public void DumpValues<T>(string sheetName, List<T> valueList)
        {

            var currWorksheet = xlPackage.Workbook.Worksheets[sheetName];
            int nextValue = currWorksheet.Dimension.End.Row + 1;
            try
            {
                currWorksheet.Cells[nextValue, 1].LoadFromCollection(valueList, false);
            }
            catch
            {


            }
        }
        public void CreateStucture<T>(string sheetName, T type)
        {
            List<string> propertyList = typeof(T).GetProperties().Select(f => f.Name).ToList();
            var currWorksheet = xlPackage.Workbook.Worksheets.Add(sheetName);
            for (int i = 0; i < propertyList.Count(); i++)
            {
                currWorksheet.Cells[1, i].Value = propertyList[i];
            }
        }
        public void Save()
        {
            xlPackage.Save();
        }
        public void SaveAs(string directory)
        {
            newFile = new FileInfo(directory);
            xlPackage.SaveAs(newFile);
        }

        public void Close()
        {
            xlPackage.Dispose();
        }
        private bool _worksheetExist(string name)
        {
            bool isThere = true;
            try
            {
                var sheet = xlPackage.Workbook.Worksheets[name];
            }
            catch (System.NullReferenceException e)
            {
                isThere = false;
            }
            return isThere;
        }
    }
}
