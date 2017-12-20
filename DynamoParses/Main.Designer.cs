namespace DynamoParses
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SplitBy = new System.Windows.Forms.TabPage();
            this.mainMenu = new System.Windows.Forms.TabControl();
            this.selectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.selectFiles = new System.Windows.Forms.OpenFileDialog();
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Directory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteButtons = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainTab = new System.Windows.Forms.TabPage();
            this.allFilesFolder = new System.Windows.Forms.Button();
            this.toExcel = new System.Windows.Forms.Button();
            this.addFiles = new System.Windows.Forms.Button();
            this.newFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fileList = new System.Windows.Forms.ListView();
            this.PatternStorage = new System.Windows.Forms.DataGridView();
            this.PatternName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsePatterns = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.selectFile = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.del = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Direcotory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExportErrorLog = new System.Windows.Forms.ListView();
            this.ExportError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.SplitBy.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.MainTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternStorage)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitBy
            // 
            this.SplitBy.Controls.Add(this.UsePatterns);
            this.SplitBy.Controls.Add(this.PatternStorage);
            this.SplitBy.Location = new System.Drawing.Point(4, 22);
            this.SplitBy.Name = "SplitBy";
            this.SplitBy.Padding = new System.Windows.Forms.Padding(3);
            this.SplitBy.Size = new System.Drawing.Size(1088, 479);
            this.SplitBy.TabIndex = 1;
            this.SplitBy.Text = "Split by";
            this.SplitBy.UseVisualStyleBackColor = true;
            // 
            // mainMenu
            // 
            this.mainMenu.Controls.Add(this.MainTab);
            this.mainMenu.Controls.Add(this.SplitBy);
            this.mainMenu.Controls.Add(this.tabPage1);
            this.mainMenu.Location = new System.Drawing.Point(1, 1);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.SelectedIndex = 0;
            this.mainMenu.Size = new System.Drawing.Size(1096, 505);
            this.mainMenu.TabIndex = 6;
            // 
            // selectFolder
            // 
            this.selectFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.selectFolder.SelectedPath = "C:\\Users\\Adam\\Documents";
            // 
            // selectFiles
            // 
            this.selectFiles.FileName = "DynamoFiles";
            this.selectFiles.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.selectFiles.Multiselect = true;
            this.selectFiles.Title = "Select files";
            this.selectFiles.FileOk += new System.ComponentModel.CancelEventHandler(this.selectFiles_FileOk);
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 87;
            // 
            // Directory
            // 
            this.Directory.Text = "Directory";
            this.Directory.Width = 831;
            // 
            // deleteButtons
            // 
            this.deleteButtons.Text = "Del";
            this.deleteButtons.Width = 30;
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.button2);
            this.MainTab.Controls.Add(this.allFilesFolder);
            this.MainTab.Controls.Add(this.toExcel);
            this.MainTab.Controls.Add(this.addFiles);
            this.MainTab.Controls.Add(this.newFiles);
            this.MainTab.Controls.Add(this.label1);
            this.MainTab.Controls.Add(this.fileList);
            this.MainTab.Location = new System.Drawing.Point(4, 22);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(1088, 479);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "Main";
            this.MainTab.UseVisualStyleBackColor = true;
            // 
            // allFilesFolder
            // 
            this.allFilesFolder.Location = new System.Drawing.Point(985, 105);
            this.allFilesFolder.Name = "allFilesFolder";
            this.allFilesFolder.Size = new System.Drawing.Size(94, 41);
            this.allFilesFolder.TabIndex = 11;
            this.allFilesFolder.Text = "All files in a folder";
            this.allFilesFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.allFilesFolder.UseVisualStyleBackColor = true;
            this.allFilesFolder.Click += new System.EventHandler(this.allFilesFolder_Click);
            // 
            // toExcel
            // 
            this.toExcel.Location = new System.Drawing.Point(9, 440);
            this.toExcel.Name = "toExcel";
            this.toExcel.Size = new System.Drawing.Size(1070, 35);
            this.toExcel.TabIndex = 10;
            this.toExcel.Text = "To Excel";
            this.toExcel.UseVisualStyleBackColor = true;
            this.toExcel.Click += new System.EventHandler(this.toExcel_Click);
            // 
            // addFiles
            // 
            this.addFiles.Location = new System.Drawing.Point(984, 76);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(95, 23);
            this.addFiles.TabIndex = 9;
            this.addFiles.Text = "Add Files";
            this.addFiles.UseVisualStyleBackColor = true;
            this.addFiles.Click += new System.EventHandler(this.addFiles_Click);
            // 
            // newFiles
            // 
            this.newFiles.Location = new System.Drawing.Point(985, 47);
            this.newFiles.Name = "newFiles";
            this.newFiles.Size = new System.Drawing.Size(95, 23);
            this.newFiles.TabIndex = 8;
            this.newFiles.Text = "Load Files";
            this.newFiles.UseVisualStyleBackColor = true;
            this.newFiles.Click += new System.EventHandler(this.newFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dynamo Parser";
            // 
            // fileList
            // 
            this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.del,
            this.Direcotory,
            this.FileType});
            this.fileList.Location = new System.Drawing.Point(15, 47);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(969, 387);
            this.fileList.TabIndex = 6;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            // 
            // PatternStorage
            // 
            this.PatternStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PatternStorage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PatternName,
            this.Pattern});
            this.PatternStorage.Location = new System.Drawing.Point(46, 41);
            this.PatternStorage.Name = "PatternStorage";
            this.PatternStorage.Size = new System.Drawing.Size(955, 416);
            this.PatternStorage.TabIndex = 0;
            this.PatternStorage.Visible = false;
            // 
            // PatternName
            // 
            this.PatternName.HeaderText = "Pattern Name";
            this.PatternName.Name = "PatternName";
            this.PatternName.Width = 400;
            // 
            // Pattern
            // 
            this.Pattern.HeaderText = "Pattern";
            this.Pattern.Name = "Pattern";
            this.Pattern.Width = 500;
            // 
            // UsePatterns
            // 
            this.UsePatterns.AutoSize = true;
            this.UsePatterns.Location = new System.Drawing.Point(46, 18);
            this.UsePatterns.Name = "UsePatterns";
            this.UsePatterns.Size = new System.Drawing.Size(204, 17);
            this.UsePatterns.TabIndex = 1;
            this.UsePatterns.Text = "Use Filename Patterns to split the files";
            this.UsePatterns.UseVisualStyleBackColor = true;
            this.UsePatterns.CheckedChanged += new System.EventHandler(this.UsePatterns_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ExportErrorLog);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1088, 479);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Export Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Template";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(29, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(898, 33);
            this.textBox1.TabIndex = 1;
            // 
            // selectFile
            // 
            this.selectFile.Title = "Please select a file";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(933, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Export Event Log";
            // 
            // del
            // 
            this.del.Text = "Del";
            this.del.Width = 29;
            // 
            // Direcotory
            // 
            this.Direcotory.Text = "Directory";
            this.Direcotory.Width = 757;
            // 
            // FileType
            // 
            this.FileType.Text = "Type";
            this.FileType.Width = 174;
            // 
            // ExportErrorLog
            // 
            this.ExportErrorLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ExportError});
            this.ExportErrorLog.Location = new System.Drawing.Point(29, 157);
            this.ExportErrorLog.Name = "ExportErrorLog";
            this.ExportErrorLog.Size = new System.Drawing.Size(1035, 314);
            this.ExportErrorLog.TabIndex = 7;
            this.ExportErrorLog.UseCompatibleStateImageBehavior = false;
            this.ExportErrorLog.View = System.Windows.Forms.View.Details;
            // 
            // ExportError
            // 
            this.ExportError.Text = "Export Errors";
            this.ExportError.Width = 1000;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(985, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "Clear List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(1095, 506);
            this.Controls.Add(this.mainMenu);
            this.Name = "Main";
            this.SplitBy.ResumeLayout(false);
            this.SplitBy.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.MainTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternStorage)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TabPage SplitBy;
        private System.Windows.Forms.TabControl mainMenu;
        private System.Windows.Forms.TabPage MainTab;
        private System.Windows.Forms.Button allFilesFolder;
        private System.Windows.Forms.Button toExcel;
        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.Button newFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.FolderBrowserDialog selectFolder;
        private System.Windows.Forms.OpenFileDialog selectFiles;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Directory;
        private System.Windows.Forms.ColumnHeader deleteButtons;
        private System.Windows.Forms.DataGridView PatternStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatternName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pattern;
        private System.Windows.Forms.CheckBox UsePatterns;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog selectFile;
        private System.Windows.Forms.ColumnHeader del;
        private System.Windows.Forms.ColumnHeader Direcotory;
        private System.Windows.Forms.ColumnHeader FileType;
        private System.Windows.Forms.ListView ExportErrorLog;
        internal System.Windows.Forms.ColumnHeader ExportError;
        private System.Windows.Forms.Button button2;
    }
}

