using DynamoParses.Models;
using DynamoParses.Parsers;
using DynamoParses.Persistence;
using DynamoParses.StoregeUnits;
using DynamoParses.UI.UIExtensions;
using DynamoParses.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace DynamoParses
{
    public partial class Main : Form
    {
        private List<DynamoFile> files;
        public List<string> errorList;


        public Main()
        {
            //ToDo: Parametry w kolumnach w Excelu
            InitializeComponent();
            fileProcessor.WorkerReportsProgress = true;
            fileProcessor.WorkerSupportsCancellation = true;
            fileList.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(fileList);
            ListViewButtonColumn buttonDelete = new ListViewButtonColumn(0);
            buttonDelete.Click += OnButtonDeleteClick;
            buttonDelete.FixedWidth = true;
            extender.AddColumn(buttonDelete);
            errorList = new List<string>();
            saveTo.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + DateTime.Today.ToString("D") + " Export.xlsx";
        }


        private void OnButtonDeleteClick(object sender, ListViewColumnMouseEventArgs e)
        {
            e.Item.Remove();
        }

        private void newFiles_Click(object sender, EventArgs e)
        {
            selectFiles.ShowDialog();
            fileList.Items.Clear();
            _addFiles(selectFiles.FileNames);
        }


        private void addFiles_Click(object sender, EventArgs e)
        {
            selectFiles.ShowDialog();
            _addFiles(selectFiles.FileNames);
        }
        private void _addFiles(string[] fileNames)
        {
            files = new List<DynamoFile>();
            foreach (string directory in fileNames)
            {
                DynamoFile thisFile = new DynamoFile(directory);
                thisFile.GetType();
                files.Add(
                    thisFile
                    );
            }
            foreach (DynamoFile file in files)
            {
                ListViewItem item = new ListViewItem(file.ReturnItem());

                fileList.Items.Add((
                    item
                    ));

            }

        }

        private void selectFiles_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void toExcel_Click(object sender, EventArgs e)
        {
            if (fileProcessor.IsBusy != true)
            {
                cancelWorker.Visible = true;
                fileProgressBar.Visible = true;
                UIParameters parameters = new UIParameters();
                parameters.groupBoxStatic = groupBoxStatic;
                parameters.groupBoxDynamic = groupBoxDynamic;
                parameters.groupBoxCommon = groupBoxCommon;
                parameters.fileList = fileList.Items.Cast<ListViewItem>().ToList();
                parameters.ExportDir = saveTo.Text;
                parameters.TemplateDir = templateDirectory.Text;

                fileProcessor.RunWorkerAsync(parameters);
            }
        }

        private void allFilesFolder_Click(object sender, EventArgs e)
        {
            selectFolder.ShowDialog();
            DirectoryInfo dinfo = new DirectoryInfo(selectFolder.SelectedPath);

            FileInfo[] Files = dinfo.GetFiles("*.txt", SearchOption.AllDirectories);
            files = new List<DynamoFile>();
            foreach (FileInfo directory in Files)
            {
                DynamoFile thisFile = new DynamoFile(directory.FullName);
                thisFile.GetType();
                files.Add(
                    thisFile
                    );
            }
            foreach (DynamoFile file in files)
            {
                ListViewItem item = new ListViewItem(file.ReturnItem());

                fileList.Items.Add((
                    item
                    ));

            }

        }
        private void UsePatterns_CheckedChanged(object sender, EventArgs e)
        {
            PatternStorage.Visible = !PatternStorage.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileList.Items.Clear();
        }


        private void selectDirectory_Click(object sender, EventArgs e)
        {
            selectFile.ShowDialog();
            templateDirectory.Text = selectFile.FileName;
        }

        private void changeExport_Click(object sender, EventArgs e)
        {
            selectFile.ShowDialog();
            saveTo.Text = selectFile.FileName;
        }

        private void fileProcessor_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int i = 0;
            double currProgress;
            BackgroundWorker worker = sender as BackgroundWorker;
            UIParameters parameters = (UIParameters)e.Argument;

            PatientStorage patients = new PatientStorage();
            List<Header> parsedHeaders = new List<Header>();

            Dictionary<string, bool> staticLaunch = new Dictionary<string, bool>();
            Dictionary<string, bool> dynamicLaunch = new Dictionary<string, bool>();

            foreach (CheckBox box in parameters.groupBoxStatic.Controls)
            {
                staticLaunch.Add(box.Text, box.Checked);
            }
            foreach (CheckBox box in parameters.groupBoxDynamic.Controls)
            {
                dynamicLaunch.Add(box.Text, box.Checked);
            }
            IEnumerable<string> dynamicDirectories = new List<string>();
            IEnumerable<string> staticDirectories = new List<string>();
            var lv = parameters.fileList;


            dynamicDirectories = from file in lv
                                 where file.SubItems[2].Text == "Dynamic"
                                 select file.SubItems[1].Text;

            staticDirectories = from file in lv
                                where file.SubItems[2].Text == "Static"
                                select file.SubItems[1].Text;


            Export export = new Export(parameters.TemplateDir);
            foreach (string file in staticDirectories)
            {
                currProgress = Convert.ToDouble(((double)++i / (double)(parameters.fileList.Count + 20))* 100);
                worker.ReportProgress(Convert.ToInt32( Math.Round(currProgress, 0)), "Processing file: " + Path.GetFileName(file));
                Static staticParser = new Static();
                staticParser.ParseFiles(file, ref patients, ref parsedHeaders, ref export, staticLaunch);
                staticParser = null;
                System.Console.WriteLine(file + " was processed at: " + DateTime.Now);
            }
            foreach (string file in dynamicDirectories)
            {
                currProgress = Convert.ToDouble(((double)++i / (double)(parameters.fileList.Count + 20)) * 100);
                worker.ReportProgress(Convert.ToInt32(Math.Round(currProgress, 0)), "Processing file: " + Path.GetFileName(file));
                Dynamic dynamicParser = new Dynamic();
                dynamicParser.ParseFiles(file, ref patients, ref parsedHeaders, ref export, dynamicLaunch);
                dynamicParser = null;
                System.Console.WriteLine(file + " was processed at: " + DateTime.Now);
            }
            currProgress = Convert.ToDouble(((double)(i+10) / (double)(parameters.fileList.Count + 20)) * 100);
            worker.ReportProgress(Convert.ToInt32(Math.Round(currProgress, 0)), "Saving the file");
            export.DumpValues<Patient>("Patients", patients.AllPatients);
            export.DumpValues<Header>("Experiments", parsedHeaders);
            export.SaveAs(parameters.ExportDir);
            worker.ReportProgress(95, "Closing the file");
            export.Close();
            export = null;
        }

    

        private void cancelWorker_Click(object sender, EventArgs e)
        {
            if (fileProcessor.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                fileProcessor.CancelAsync();
            }
        }

        private void fileProcessor_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                progressLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                progressLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                progressLabel.Text = "Done! File Saved to:" + saveTo.Text;
            }
            cancelWorker.Visible = false;
            fileProgressBar.Visible = false;
        }

        private void fileProcessor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressLabel.Text = e.UserState.ToString();
            fileProgressBar.Value = e.ProgressPercentage;
        }
    }
}
