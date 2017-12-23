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
            this.UsePatterns = new System.Windows.Forms.CheckBox();
            this.PatternStorage = new System.Windows.Forms.DataGridView();
            this.PatternName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenu = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.fileProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelWorker = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.allFilesFolder = new System.Windows.Forms.Button();
            this.toExcel = new System.Windows.Forms.Button();
            this.addFiles = new System.Windows.Forms.Button();
            this.newFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fileList = new System.Windows.Forms.ListView();
            this.del = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Direcotory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxCommon = new System.Windows.Forms.GroupBox();
            this.checkBoxExperiments = new System.Windows.Forms.CheckBox();
            this.checkBoxPatients = new System.Windows.Forms.CheckBox();
            this.groupBoxDynamic = new System.Windows.Forms.GroupBox();
            this.maxForces = new System.Windows.Forms.CheckBox();
            this.ForceOverlays = new System.Windows.Forms.CheckBox();
            this.checkBoxDynamicParameters = new System.Windows.Forms.CheckBox();
            this.checkBoxOtherPreassures = new System.Windows.Forms.CheckBox();
            this.checkBoxButterflyParameters = new System.Windows.Forms.CheckBox();
            this.checkBoxPreassures = new System.Windows.Forms.CheckBox();
            this.groupBoxStatic = new System.Windows.Forms.GroupBox();
            this.checkBoxStaticParameters = new System.Windows.Forms.CheckBox();
            this.checkBoxSideForces = new System.Windows.Forms.CheckBox();
            this.checkBoxCOPTracks = new System.Windows.Forms.CheckBox();
            this.checkBoxCOPAverages = new System.Windows.Forms.CheckBox();
            this.exportDetails = new System.Windows.Forms.Label();
            this.changeExport = new System.Windows.Forms.Button();
            this.saveTo = new System.Windows.Forms.TextBox();
            this.saveToLabel = new System.Windows.Forms.Label();
            this.selectDirectory = new System.Windows.Forms.Button();
            this.templateDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.selectFiles = new System.Windows.Forms.OpenFileDialog();
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Directory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteButtons = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectFile = new System.Windows.Forms.OpenFileDialog();
            this.fileProcessor = new System.ComponentModel.BackgroundWorker();
            this.otherParametes = new System.Windows.Forms.CheckBox();
            this.SplitBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternStorage)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxCommon.SuspendLayout();
            this.groupBoxDynamic.SuspendLayout();
            this.groupBoxStatic.SuspendLayout();
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
            // MainTab
            // 
            this.MainTab.Controls.Add(this.fileProgressBar);
            this.MainTab.Controls.Add(this.cancelWorker);
            this.MainTab.Controls.Add(this.progressLabel);
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
            // fileProgressBar
            // 
            this.fileProgressBar.Location = new System.Drawing.Point(9, 407);
            this.fileProgressBar.Name = "fileProgressBar";
            this.fileProgressBar.Size = new System.Drawing.Size(1069, 35);
            this.fileProgressBar.TabIndex = 15;
            this.fileProgressBar.Visible = false;
            // 
            // cancelWorker
            // 
            this.cancelWorker.BackColor = System.Drawing.Color.Red;
            this.cancelWorker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cancelWorker.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelWorker.Location = new System.Drawing.Point(985, 189);
            this.cancelWorker.Name = "cancelWorker";
            this.cancelWorker.Size = new System.Drawing.Size(95, 27);
            this.cancelWorker.TabIndex = 14;
            this.cancelWorker.Text = "Cancel";
            this.cancelWorker.UseVisualStyleBackColor = false;
            this.cancelWorker.Visible = false;
            this.cancelWorker.Click += new System.EventHandler(this.cancelWorker_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.Location = new System.Drawing.Point(10, 449);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(369, 25);
            this.progressLabel.TabIndex = 13;
            this.progressLabel.Text = "Click the export button to proceed";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.toExcel.Location = new System.Drawing.Point(9, 407);
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
            this.fileList.Size = new System.Drawing.Size(969, 354);
            this.fileList.TabIndex = 6;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxCommon);
            this.tabPage1.Controls.Add(this.groupBoxDynamic);
            this.tabPage1.Controls.Add(this.groupBoxStatic);
            this.tabPage1.Controls.Add(this.exportDetails);
            this.tabPage1.Controls.Add(this.changeExport);
            this.tabPage1.Controls.Add(this.saveTo);
            this.tabPage1.Controls.Add(this.saveToLabel);
            this.tabPage1.Controls.Add(this.selectDirectory);
            this.tabPage1.Controls.Add(this.templateDirectory);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1088, 479);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Export Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxCommon
            // 
            this.groupBoxCommon.Controls.Add(this.checkBoxExperiments);
            this.groupBoxCommon.Controls.Add(this.checkBoxPatients);
            this.groupBoxCommon.Location = new System.Drawing.Point(503, 251);
            this.groupBoxCommon.Name = "groupBoxCommon";
            this.groupBoxCommon.Size = new System.Drawing.Size(221, 220);
            this.groupBoxCommon.TabIndex = 9;
            this.groupBoxCommon.TabStop = false;
            this.groupBoxCommon.Text = "Common";
            // 
            // checkBoxExperiments
            // 
            this.checkBoxExperiments.AutoSize = true;
            this.checkBoxExperiments.Checked = true;
            this.checkBoxExperiments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExperiments.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExperiments.Location = new System.Drawing.Point(6, 47);
            this.checkBoxExperiments.Name = "checkBoxExperiments";
            this.checkBoxExperiments.Size = new System.Drawing.Size(137, 22);
            this.checkBoxExperiments.TabIndex = 5;
            this.checkBoxExperiments.Text = "Experiments";
            this.checkBoxExperiments.UseVisualStyleBackColor = true;
            // 
            // checkBoxPatients
            // 
            this.checkBoxPatients.AutoSize = true;
            this.checkBoxPatients.Checked = true;
            this.checkBoxPatients.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPatients.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPatients.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPatients.Name = "checkBoxPatients";
            this.checkBoxPatients.Size = new System.Drawing.Size(99, 22);
            this.checkBoxPatients.TabIndex = 4;
            this.checkBoxPatients.Text = "Patients";
            this.checkBoxPatients.UseVisualStyleBackColor = true;
            // 
            // groupBoxDynamic
            // 
            this.groupBoxDynamic.Controls.Add(this.otherParametes);
            this.groupBoxDynamic.Controls.Add(this.maxForces);
            this.groupBoxDynamic.Controls.Add(this.ForceOverlays);
            this.groupBoxDynamic.Controls.Add(this.checkBoxDynamicParameters);
            this.groupBoxDynamic.Controls.Add(this.checkBoxOtherPreassures);
            this.groupBoxDynamic.Controls.Add(this.checkBoxButterflyParameters);
            this.groupBoxDynamic.Controls.Add(this.checkBoxPreassures);
            this.groupBoxDynamic.Location = new System.Drawing.Point(266, 251);
            this.groupBoxDynamic.Name = "groupBoxDynamic";
            this.groupBoxDynamic.Size = new System.Drawing.Size(221, 220);
            this.groupBoxDynamic.TabIndex = 8;
            this.groupBoxDynamic.TabStop = false;
            this.groupBoxDynamic.Text = "Dynamic";
            // 
            // maxForces
            // 
            this.maxForces.AutoSize = true;
            this.maxForces.Checked = true;
            this.maxForces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maxForces.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxForces.Location = new System.Drawing.Point(6, 159);
            this.maxForces.Name = "maxForces";
            this.maxForces.Size = new System.Drawing.Size(127, 22);
            this.maxForces.TabIndex = 9;
            this.maxForces.Text = "Max Forces";
            this.maxForces.UseVisualStyleBackColor = true;
            // 
            // ForceOverlays
            // 
            this.ForceOverlays.AutoSize = true;
            this.ForceOverlays.Checked = true;
            this.ForceOverlays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ForceOverlays.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForceOverlays.Location = new System.Drawing.Point(6, 131);
            this.ForceOverlays.Name = "ForceOverlays";
            this.ForceOverlays.Size = new System.Drawing.Size(158, 22);
            this.ForceOverlays.TabIndex = 8;
            this.ForceOverlays.Text = "Force Overlays";
            this.ForceOverlays.UseVisualStyleBackColor = true;
            // 
            // checkBoxDynamicParameters
            // 
            this.checkBoxDynamicParameters.AutoSize = true;
            this.checkBoxDynamicParameters.Checked = true;
            this.checkBoxDynamicParameters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDynamicParameters.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDynamicParameters.Location = new System.Drawing.Point(6, 103);
            this.checkBoxDynamicParameters.Name = "checkBoxDynamicParameters";
            this.checkBoxDynamicParameters.Size = new System.Drawing.Size(131, 22);
            this.checkBoxDynamicParameters.TabIndex = 7;
            this.checkBoxDynamicParameters.Text = "Parameters";
            this.checkBoxDynamicParameters.UseVisualStyleBackColor = true;
            // 
            // checkBoxOtherPreassures
            // 
            this.checkBoxOtherPreassures.AutoSize = true;
            this.checkBoxOtherPreassures.Checked = true;
            this.checkBoxOtherPreassures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOtherPreassures.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOtherPreassures.Location = new System.Drawing.Point(6, 75);
            this.checkBoxOtherPreassures.Name = "checkBoxOtherPreassures";
            this.checkBoxOtherPreassures.Size = new System.Drawing.Size(182, 22);
            this.checkBoxOtherPreassures.TabIndex = 6;
            this.checkBoxOtherPreassures.Text = "Other Preassures";
            this.checkBoxOtherPreassures.UseMnemonic = false;
            this.checkBoxOtherPreassures.UseVisualStyleBackColor = true;
            // 
            // checkBoxButterflyParameters
            // 
            this.checkBoxButterflyParameters.AutoSize = true;
            this.checkBoxButterflyParameters.Checked = true;
            this.checkBoxButterflyParameters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxButterflyParameters.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxButterflyParameters.Location = new System.Drawing.Point(6, 47);
            this.checkBoxButterflyParameters.Name = "checkBoxButterflyParameters";
            this.checkBoxButterflyParameters.Size = new System.Drawing.Size(213, 22);
            this.checkBoxButterflyParameters.TabIndex = 5;
            this.checkBoxButterflyParameters.Text = "Butterfly Parameters";
            this.checkBoxButterflyParameters.UseVisualStyleBackColor = true;
            // 
            // checkBoxPreassures
            // 
            this.checkBoxPreassures.AutoSize = true;
            this.checkBoxPreassures.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPreassures.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPreassures.Name = "checkBoxPreassures";
            this.checkBoxPreassures.Size = new System.Drawing.Size(126, 22);
            this.checkBoxPreassures.TabIndex = 4;
            this.checkBoxPreassures.Text = "Preassures";
            this.checkBoxPreassures.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatic
            // 
            this.groupBoxStatic.Controls.Add(this.checkBoxStaticParameters);
            this.groupBoxStatic.Controls.Add(this.checkBoxSideForces);
            this.groupBoxStatic.Controls.Add(this.checkBoxCOPTracks);
            this.groupBoxStatic.Controls.Add(this.checkBoxCOPAverages);
            this.groupBoxStatic.Location = new System.Drawing.Point(29, 251);
            this.groupBoxStatic.Name = "groupBoxStatic";
            this.groupBoxStatic.Size = new System.Drawing.Size(221, 220);
            this.groupBoxStatic.TabIndex = 7;
            this.groupBoxStatic.TabStop = false;
            this.groupBoxStatic.Text = "Static";
            // 
            // checkBoxStaticParameters
            // 
            this.checkBoxStaticParameters.AutoSize = true;
            this.checkBoxStaticParameters.Checked = true;
            this.checkBoxStaticParameters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStaticParameters.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStaticParameters.Location = new System.Drawing.Point(7, 104);
            this.checkBoxStaticParameters.Name = "checkBoxStaticParameters";
            this.checkBoxStaticParameters.Size = new System.Drawing.Size(131, 22);
            this.checkBoxStaticParameters.TabIndex = 3;
            this.checkBoxStaticParameters.Text = "Parameters";
            this.checkBoxStaticParameters.UseVisualStyleBackColor = true;
            // 
            // checkBoxSideForces
            // 
            this.checkBoxSideForces.AutoSize = true;
            this.checkBoxSideForces.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSideForces.Location = new System.Drawing.Point(7, 76);
            this.checkBoxSideForces.Name = "checkBoxSideForces";
            this.checkBoxSideForces.Size = new System.Drawing.Size(127, 22);
            this.checkBoxSideForces.TabIndex = 2;
            this.checkBoxSideForces.Text = "Side Forces";
            this.checkBoxSideForces.UseMnemonic = false;
            this.checkBoxSideForces.UseVisualStyleBackColor = true;
            // 
            // checkBoxCOPTracks
            // 
            this.checkBoxCOPTracks.AutoSize = true;
            this.checkBoxCOPTracks.Checked = true;
            this.checkBoxCOPTracks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCOPTracks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCOPTracks.Location = new System.Drawing.Point(7, 48);
            this.checkBoxCOPTracks.Name = "checkBoxCOPTracks";
            this.checkBoxCOPTracks.Size = new System.Drawing.Size(129, 22);
            this.checkBoxCOPTracks.TabIndex = 1;
            this.checkBoxCOPTracks.Text = "COP Tracks";
            this.checkBoxCOPTracks.UseVisualStyleBackColor = true;
            // 
            // checkBoxCOPAverages
            // 
            this.checkBoxCOPAverages.AutoSize = true;
            this.checkBoxCOPAverages.Checked = true;
            this.checkBoxCOPAverages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCOPAverages.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCOPAverages.Location = new System.Drawing.Point(7, 20);
            this.checkBoxCOPAverages.Name = "checkBoxCOPAverages";
            this.checkBoxCOPAverages.Size = new System.Drawing.Size(153, 22);
            this.checkBoxCOPAverages.TabIndex = 0;
            this.checkBoxCOPAverages.Text = "COP Averages";
            this.checkBoxCOPAverages.UseVisualStyleBackColor = true;
            // 
            // exportDetails
            // 
            this.exportDetails.AutoSize = true;
            this.exportDetails.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportDetails.Location = new System.Drawing.Point(23, 216);
            this.exportDetails.Name = "exportDetails";
            this.exportDetails.Size = new System.Drawing.Size(238, 32);
            this.exportDetails.TabIndex = 6;
            this.exportDetails.Text = "Export Details:";
            // 
            // changeExport
            // 
            this.changeExport.Location = new System.Drawing.Point(934, 169);
            this.changeExport.Name = "changeExport";
            this.changeExport.Size = new System.Drawing.Size(130, 33);
            this.changeExport.TabIndex = 5;
            this.changeExport.Text = "Change...";
            this.changeExport.UseVisualStyleBackColor = true;
            this.changeExport.Click += new System.EventHandler(this.changeExport_Click);
            // 
            // saveTo
            // 
            this.saveTo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveTo.Location = new System.Drawing.Point(29, 169);
            this.saveTo.Name = "saveTo";
            this.saveTo.ReadOnly = true;
            this.saveTo.Size = new System.Drawing.Size(898, 33);
            this.saveTo.TabIndex = 4;
            // 
            // saveToLabel
            // 
            this.saveToLabel.AutoSize = true;
            this.saveToLabel.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToLabel.Location = new System.Drawing.Point(23, 117);
            this.saveToLabel.Name = "saveToLabel";
            this.saveToLabel.Size = new System.Drawing.Size(145, 32);
            this.saveToLabel.TabIndex = 3;
            this.saveToLabel.Text = "Save To:";
            // 
            // selectDirectory
            // 
            this.selectDirectory.Location = new System.Drawing.Point(933, 65);
            this.selectDirectory.Name = "selectDirectory";
            this.selectDirectory.Size = new System.Drawing.Size(131, 33);
            this.selectDirectory.TabIndex = 2;
            this.selectDirectory.Text = "Select...";
            this.selectDirectory.UseVisualStyleBackColor = true;
            this.selectDirectory.Click += new System.EventHandler(this.selectDirectory_Click);
            // 
            // templateDirectory
            // 
            this.templateDirectory.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateDirectory.Location = new System.Drawing.Point(29, 65);
            this.templateDirectory.Name = "templateDirectory";
            this.templateDirectory.ReadOnly = true;
            this.templateDirectory.Size = new System.Drawing.Size(898, 33);
            this.templateDirectory.TabIndex = 1;
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
            // selectFile
            // 
            this.selectFile.Title = "Please select a file";
            // 
            // fileProcessor
            // 
            this.fileProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fileProcessor_DoWork);
            this.fileProcessor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fileProcessor_ProgressChanged);
            this.fileProcessor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileProcessor_RunWorkerCompleted);
            // 
            // otherParametes
            // 
            this.otherParametes.AutoSize = true;
            this.otherParametes.Checked = true;
            this.otherParametes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.otherParametes.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherParametes.Location = new System.Drawing.Point(6, 187);
            this.otherParametes.Name = "otherParametes";
            this.otherParametes.Size = new System.Drawing.Size(187, 22);
            this.otherParametes.TabIndex = 10;
            this.otherParametes.Text = "Other Parameters";
            this.otherParametes.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(1095, 506);
            this.Controls.Add(this.mainMenu);
            this.Name = "Main";
            this.SplitBy.ResumeLayout(false);
            this.SplitBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternStorage)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.MainTab.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxCommon.ResumeLayout(false);
            this.groupBoxCommon.PerformLayout();
            this.groupBoxDynamic.ResumeLayout(false);
            this.groupBoxDynamic.PerformLayout();
            this.groupBoxStatic.ResumeLayout(false);
            this.groupBoxStatic.PerformLayout();
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
        private System.Windows.Forms.Button selectDirectory;
        private System.Windows.Forms.TextBox templateDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog selectFile;
        private System.Windows.Forms.ColumnHeader del;
        private System.Windows.Forms.ColumnHeader Direcotory;
        private System.Windows.Forms.ColumnHeader FileType;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox saveTo;
        private System.Windows.Forms.Label saveToLabel;
        private System.Windows.Forms.Button changeExport;
        private System.Windows.Forms.GroupBox groupBoxCommon;
        private System.Windows.Forms.CheckBox checkBoxExperiments;
        private System.Windows.Forms.CheckBox checkBoxPatients;
        private System.Windows.Forms.GroupBox groupBoxDynamic;
        private System.Windows.Forms.CheckBox ForceOverlays;
        private System.Windows.Forms.CheckBox checkBoxDynamicParameters;
        private System.Windows.Forms.CheckBox checkBoxOtherPreassures;
        private System.Windows.Forms.CheckBox checkBoxButterflyParameters;
        private System.Windows.Forms.CheckBox checkBoxPreassures;
        private System.Windows.Forms.GroupBox groupBoxStatic;
        private System.Windows.Forms.CheckBox checkBoxStaticParameters;
        private System.Windows.Forms.CheckBox checkBoxSideForces;
        private System.Windows.Forms.CheckBox checkBoxCOPTracks;
        private System.Windows.Forms.CheckBox checkBoxCOPAverages;
        private System.Windows.Forms.Label exportDetails;
        private System.ComponentModel.BackgroundWorker fileProcessor;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button cancelWorker;
        private System.Windows.Forms.ProgressBar fileProgressBar;
        private System.Windows.Forms.CheckBox maxForces;
        private System.Windows.Forms.CheckBox otherParametes;
    }
}

