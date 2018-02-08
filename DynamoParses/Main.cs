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
                if (templateDirectory.Text == "")
                {
                    selectFile.Title = "No Template selected please select one!";
                    selectFile.ShowDialog();
                    templateDirectory.Text = selectFile.FileName;     
                }

                parameters.TemplateDir = templateDirectory.Text;
                fileProcessor.RunWorkerAsync(parameters);
            }
        }

        private void allFilesFolder_Click(object sender, EventArgs e)
        {
            selectFolder.ShowDialog();
            DirectoryInfo dinfo = new DirectoryInfo(selectFolder.SelectedPath);
            try
            {
                FileInfo[] Files = dinfo.GetFiles("*.txt", SearchOption.AllDirectories);
                if (!Files.Any())
                    return;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
            if (selectFile.FileName == null)
                return;
            templateDirectory.Text = selectFile.FileName;
        }

        private void changeExport_Click(object sender, EventArgs e)
        {
            selectFile.ShowDialog();
            if (selectFile.FileName == null)
                return;
            saveTo.Text = selectFile.FileName;
        }

        private void fileProcessor_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            double currProgress;
            BackgroundWorker worker = sender as BackgroundWorker;
            UIParameters parameters = (UIParameters)e.Argument;



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
            ParserParent parserClass = new ParserParent(worker);
            parserClass.dynamicLaunch = dynamicLaunch;
            parserClass.staticLaunch = staticLaunch;
            parserClass.parameters = parameters;
            if (UsePatterns.Checked)
            {
                parserClass.SplitFiles(PatternStorage);
            }
            else
            {
                parserClass.InOneGo();
            }
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
