using DynamoParses.Models;
using DynamoParses.Persistence;
using DynamoParses.StoregeUnits;
using DynamoParses.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Todo: Ustawienia regionalne
//Todo: Zamienić prawda fałsz na 1 i 0 
namespace DynamoParses.Parsers
{
    class ParserParent
    {
        public UIParameters parameters { get; set; }
        public Dictionary<string, bool> staticLaunch { get; set; }
        public Dictionary<string, bool> dynamicLaunch { get; set; }
        private BackgroundWorker worker { get; set; }
        public PatientStorage patients { get; set; }
        private double currProgress { get; set; }
        private double actionsCompleted { get; set; }

        public ParserParent(BackgroundWorker bWorker)
        {
            patients = new PatientStorage();
            worker = bWorker;
            currProgress = 0;
            actionsCompleted = 0;
        }

        public void InOneGo()
        {
            RunParser(parameters.fileList);
        }

        public void SplitFiles(DataGridView splitGrid)
        {
            string pattern;
            string patternName; 
            foreach (DataGridViewRow row in splitGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    patternName = row.Cells["PatternName"].Value.ToString();
                    pattern = row.Cells["Pattern"].Value.ToString();

                    var newFileList = from file in parameters.fileList
                                      where file.SubItems[1].Text.ToString().Contains(pattern)
                                      select file;
                    RunParser(newFileList.ToList(), patternName);
                }
            }
        }
        private void RunParser(List<ListViewItem> lv, string fileNameSuffix = null)
        {
            List<StudyHeader> parsedHeaders = new List<StudyHeader>();
            IEnumerable<string> dynamicDirectories = new List<string>();
            IEnumerable<string> staticDirectories = new List<string>();


            dynamicDirectories = from file in lv
                                 where file.SubItems[2].Text == "Dynamic"
                                 select file.SubItems[1].Text;

            staticDirectories = from file in lv
                                where file.SubItems[2].Text == "Static"
                                select file.SubItems[1].Text;

            currProgress = Convert.ToDouble((0.00 / (double)(parameters.fileList.Count + 20)) * 100);
            worker.ReportProgress(Convert.ToInt32(Math.Round(currProgress, 0)), "Setting up the parsers");
            Export export = new Export(parameters.TemplateDir);
            foreach (string file in staticDirectories)
            {
                currProgress = Convert.ToDouble((++actionsCompleted / (double)(parameters.fileList.Count + 20)) * 100);
                worker.ReportProgress(Convert.ToInt32(Math.Round(currProgress, 0)), "Processing file: " + Path.GetFileName(file));
                Static staticParser = new Static();
                staticParser.ParseFiles(file, patients, ref parsedHeaders, ref export, staticLaunch);
                staticParser = null;
            }
            foreach (string file in dynamicDirectories)
            {
                currProgress = Convert.ToDouble((++actionsCompleted / (double)(parameters.fileList.Count + 20)) * 100);
                worker.ReportProgress(Convert.ToInt32(Math.Round(currProgress, 0)), "Processing file: " + Path.GetFileName(file));
                Dynamic dynamicParser = new Dynamic();
                dynamicParser.ParseFiles(file, patients, ref parsedHeaders, ref export, dynamicLaunch);
                dynamicParser = null;
            }
            currProgress = Convert.ToDouble((++actionsCompleted / (double)(parameters.fileList.Count + 20)) * 100);
            worker.ReportProgress(Convert.ToInt32(Math.Round(currProgress, 0)), "Saving the file");
            export.DumpValues<Patient>("Patients", patients.AllPatients);
            export.DumpValues<StudyHeader>("Experiments", parsedHeaders);
            export.SaveAs(Path.GetDirectoryName(parameters.ExportDir) + @"\" +  Path.GetFileNameWithoutExtension(parameters.ExportDir) + fileNameSuffix + ".xlsx");
            worker.ReportProgress(95, "Closing the file");
            export.Close();
            export = null;
        }
    }
}
