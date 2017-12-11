using DynamoParses.Models;
using DynamoParses.Parsers;
using DynamoParses.Persistence;
using DynamoParses.StoregeUnits;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DynamoParses
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            PatientStorage patients = new PatientStorage();
            List<Header> parsedHeaders = new List<Header>();
            Export export = new Export();

            List<string> directories = new List<string>(
                    new string[]
                    {
                        @"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, buty 1.txt",
                        @"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, b2.txt",
                        @"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, bb 1.txt",
                        @"C:\Users\Adam\Source\Repos\Rozlicznik\DynamoParses\DynamoParses\Resources\Borowiecka M, dynamika, bb 2.txt"
                    }
                );

            Dynamic.ParseFiles(directories,ref patients,ref parsedHeaders,ref export);
            export.DumpValues<Patient>("Patients", patients.AllPatients);
            export.DumpValues<Header>("Experiments", parsedHeaders);
            export.Save(@"c:\temp\Data_Test.xlsx");
        }

    }
}
