using DynamoParses.Models;
using DynamoParses.Parsers;
using DynamoParses.Persistence;
using DynamoParses.StoregeUnits;
using DynamoParses.UI.UIExtensions;
using DynamoParses.UI.ViewModels;
using System;
using System.Collections.Generic;
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
            fileList.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(fileList);
            ListViewButtonColumn buttonDelete = new ListViewButtonColumn(0);
            buttonDelete.Click += OnButtonDeleteClick;
            buttonDelete.FixedWidth = true;
            extender.AddColumn(buttonDelete);
            errorList = new List<string>();
        }

        public void AddToLog(string message)
        {
            ListViewItem item = new ListViewItem(new[] { message });
            ExportErrorLog.Items.Add(item);
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
            PatientStorage patients = new PatientStorage();
            List<Header> parsedHeaders = new List<Header>();


            IEnumerable<string> dynamicDirectories = new List<string>();
            IEnumerable<string> staticDirectories = new List<string>();
            var lv = fileList.Items.Cast<ListViewItem>().ToList();


            dynamicDirectories = from file in lv
                                 where file.SubItems[2].Text == "Dynamic"
                                 select file.SubItems[1].Text;

            staticDirectories = from file in lv
                                where file.SubItems[2].Text == "Static"
                                select file.SubItems[1].Text;


            Dynamic dynamicParser = Dynamic.Instance;
            Static staticParser = Static.Instance;

            staticParser.ParseFiles(staticDirectories.ToList(), ref patients, ref parsedHeaders);
            dynamicParser.ParseFiles(dynamicDirectories.ToList(), ref patients, ref parsedHeaders);
            Export export = new Export(@"c:\temp\Data_Test_Final.xlsx");
            export.DumpValues<Patient>("Patients", patients.AllPatients);
            export.DumpValues<Header>("Experiments", parsedHeaders);
            export.DumpValues("COPAverages", staticParser.parsedCOPAvereges);
            export.DumpValues("COPTracks", staticParser.parsedCOPTracks);
            export.DumpValues("SideForces", staticParser.parsedSideForces);
            export.DumpValues("StaticParameters", staticParser.parsedParameters);
            export.DumpValues("Preassures", dynamicParser.parsedPreassures);
            export.DumpValues("DynamicParameters", dynamicParser.parsedParameters);
            export.DumpValues("ButterflyParameters", dynamicParser.parsedButterflyParameters);
            export.DumpValues("OtherPreassures", dynamicParser.parsedOtherPressures);
            export.DumpValues("ForceOverlays", dynamicParser.parsedForceOverlays);
            export.Save();
            export.Close();
            export = null;
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
    }
}
