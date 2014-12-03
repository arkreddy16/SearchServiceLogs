namespace SearchServiceLogs
{
    partial class frmSearchServiceLogs
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetOutputFilePath = new System.Windows.Forms.Button();
            this.chkExportResults = new System.Windows.Forms.CheckBox();
            this.lblExportDirectoryLabel = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.cbDeviceType = new System.Windows.Forms.ComboBox();
            this.lblDirectoryPath = new System.Windows.Forms.Label();
            this.lbloutputDirectoryPath = new System.Windows.Forms.Label();
            this.btnSetDirectoryPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device Type :-";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(349, 171);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Start Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.dgvSearchResults);
            this.groupBox1.Location = new System.Drawing.Point(12, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 312);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Results";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(352, 280);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export Results";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.Location = new System.Drawing.Point(3, 16);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.Size = new System.Drawing.Size(491, 258);
            this.dgvSearchResults.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetOutputFilePath);
            this.groupBox2.Controls.Add(this.chkExportResults);
            this.groupBox2.Controls.Add(this.lblExportDirectoryLabel);
            this.groupBox2.Controls.Add(this.lblStats);
            this.groupBox2.Controls.Add(this.cbDeviceType);
            this.groupBox2.Controls.Add(this.lblDirectoryPath);
            this.groupBox2.Controls.Add(this.lbloutputDirectoryPath);
            this.groupBox2.Controls.Add(this.btnSetDirectoryPath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 210);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Files Search Criteria";
            // 
            // btnSetOutputFilePath
            // 
            this.btnSetOutputFilePath.Location = new System.Drawing.Point(137, 115);
            this.btnSetOutputFilePath.Name = "btnSetOutputFilePath";
            this.btnSetOutputFilePath.Size = new System.Drawing.Size(139, 23);
            this.btnSetOutputFilePath.TabIndex = 13;
            this.btnSetOutputFilePath.Text = "Set Directory Path";
            this.btnSetOutputFilePath.UseVisualStyleBackColor = true;
            this.btnSetOutputFilePath.Click += new System.EventHandler(this.btnSetOutputFilePath_Click);
            // 
            // chkExportResults
            // 
            this.chkExportResults.AutoSize = true;
            this.chkExportResults.Location = new System.Drawing.Point(137, 92);
            this.chkExportResults.Name = "chkExportResults";
            this.chkExportResults.Size = new System.Drawing.Size(131, 17);
            this.chkExportResults.TabIndex = 12;
            this.chkExportResults.Text = "Export Search Results";
            this.chkExportResults.UseVisualStyleBackColor = true;
            this.chkExportResults.CheckStateChanged += new System.EventHandler(this.chkExportResults_CheckStateChanged);
            // 
            // lblExportDirectoryLabel
            // 
            this.lblExportDirectoryLabel.AutoSize = true;
            this.lblExportDirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportDirectoryLabel.Location = new System.Drawing.Point(-1, 120);
            this.lblExportDirectoryLabel.Name = "lblExportDirectoryLabel";
            this.lblExportDirectoryLabel.Size = new System.Drawing.Size(134, 13);
            this.lblExportDirectoryLabel.TabIndex = 11;
            this.lblExportDirectoryLabel.Text = "Select Exported File path :-";
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStats.Location = new System.Drawing.Point(330, 73);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(0, 13);
            this.lblStats.TabIndex = 8;
            // 
            // cbDeviceType
            // 
            this.cbDeviceType.FormattingEnabled = true;
            this.cbDeviceType.Items.AddRange(new object[] {
            "---Select Device Type---",
            "IPhone",
            "Android"});
            this.cbDeviceType.Location = new System.Drawing.Point(137, 65);
            this.cbDeviceType.Name = "cbDeviceType";
            this.cbDeviceType.Size = new System.Drawing.Size(174, 21);
            this.cbDeviceType.TabIndex = 10;
            // 
            // lblDirectoryPath
            // 
            this.lblDirectoryPath.AutoSize = true;
            this.lblDirectoryPath.ForeColor = System.Drawing.Color.Green;
            this.lblDirectoryPath.Location = new System.Drawing.Point(283, 34);
            this.lblDirectoryPath.Name = "lblDirectoryPath";
            this.lblDirectoryPath.Size = new System.Drawing.Size(0, 13);
            this.lblDirectoryPath.TabIndex = 9;
            this.lblDirectoryPath.DoubleClick += new System.EventHandler(this.lblDirectoryPath_DoubleClick);
            // 
            // lbloutputDirectoryPath
            // 
            this.lbloutputDirectoryPath.AutoSize = true;
            this.lbloutputDirectoryPath.ForeColor = System.Drawing.Color.Green;
            this.lbloutputDirectoryPath.Location = new System.Drawing.Point(134, 141);
            this.lbloutputDirectoryPath.Name = "lbloutputDirectoryPath";
            this.lbloutputDirectoryPath.Size = new System.Drawing.Size(0, 13);
            this.lbloutputDirectoryPath.TabIndex = 9;
            // 
            // btnSetDirectoryPath
            // 
            this.btnSetDirectoryPath.Location = new System.Drawing.Point(137, 29);
            this.btnSetDirectoryPath.Name = "btnSetDirectoryPath";
            this.btnSetDirectoryPath.Size = new System.Drawing.Size(139, 23);
            this.btnSetDirectoryPath.TabIndex = 8;
            this.btnSetDirectoryPath.Text = "Set Directory Path";
            this.btnSetDirectoryPath.UseVisualStyleBackColor = true;
            this.btnSetDirectoryPath.Click += new System.EventHandler(this.btnSetDirectoryPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select log file path :-";
            // 
            // frmSearchServiceLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(525, 552);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSearchServiceLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Service Logs";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSetDirectoryPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDirectoryPath;
        private System.Windows.Forms.Label lbloutputDirectoryPath;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cbDeviceType;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnSetOutputFilePath;
        private System.Windows.Forms.CheckBox chkExportResults;
        private System.Windows.Forms.Label lblExportDirectoryLabel;
    }
}