using ClosedXML.Excel;
using DynamoParses.Models;
using DynamoParses.Parsers;
using DynamoParses.StoregeUnits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamoParses
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HeaderStorage headers = new HeaderStorage();
            ParameterStorage parameters = new ParameterStorage();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, buty 1.txt");
            string gather = "none";
            List<PressureMeasurement> preasures = new List<PressureMeasurement>();
            Pressures parser = new Pressures();
            foreach (var line in lines)
            {
                Match match = Regex.Match(line, @"\[([^)]*)\]");
                if (match.Success)
                {
                    gather = match.Groups[1].Value;
                }
                //if (line.Contains("[Left]"))
                //{
                //    gather = "Left";
                //}
                //else if (line.Contains("[Butterfly]"))
                //{
                //    gather = "end";
                //}

                switch (gather)
                {
                    case "Left":
                        preasures.Add(parser.parsePressures(line));
                        break;
                    case "end":
                        var wb = new XLWorkbook();
                        var ws = wb.Worksheets.Add("Data_Test_Worksheet");
                        ws.Cell(1, 1).Value ="Force (N)";
                        ws.Cell(1, 2).Value = "X (mm)";
                        ws.Cell(1, 3).Value = "Y (mm)";
                        ws.Cell(2, 1).InsertData(preasures);

                        wb.SaveAs(@"c:\temp\Data_Test.xlsx");
                        return;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
