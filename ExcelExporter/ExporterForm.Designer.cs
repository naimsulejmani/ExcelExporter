namespace ExcelExporter
{
    partial class ExporterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExporterForm));
            this.chbOpenFile = new System.Windows.Forms.CheckBox();
            this.lblSaveToPath = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.rtbSqlQuery = new System.Windows.Forms.RichTextBox();
            this.btnGenerateQueryTable = new System.Windows.Forms.Button();
            this.lblObject = new System.Windows.Forms.Label();
            this.cbObjectNames = new System.Windows.Forms.ComboBox();
            this.cbObjectTypes = new System.Windows.Forms.ComboBox();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.lblServerAndDataBase = new System.Windows.Forms.Label();
            this.lblServerAndDataBaseInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chbOpenFile
            // 
            this.chbOpenFile.AutoSize = true;
            this.chbOpenFile.Location = new System.Drawing.Point(417, 430);
            this.chbOpenFile.Name = "chbOpenFile";
            this.chbOpenFile.Size = new System.Drawing.Size(68, 17);
            this.chbOpenFile.TabIndex = 25;
            this.chbOpenFile.Text = "OpenFile";
            this.chbOpenFile.UseVisualStyleBackColor = true;
            // 
            // lblSaveToPath
            // 
            this.lblSaveToPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaveToPath.AutoSize = true;
            this.lblSaveToPath.Location = new System.Drawing.Point(12, 430);
            this.lblSaveToPath.Name = "lblSaveToPath";
            this.lblSaveToPath.Size = new System.Drawing.Size(32, 13);
            this.lblSaveToPath.TabIndex = 24;
            this.lblSaveToPath.Text = "Path:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileName.Location = new System.Drawing.Point(50, 428);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(291, 20);
            this.txtFileName.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(347, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Browse";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(491, 425);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // rtbSqlQuery
            // 
            this.rtbSqlQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSqlQuery.Location = new System.Drawing.Point(12, 90);
            this.rtbSqlQuery.Name = "rtbSqlQuery";
            this.rtbSqlQuery.Size = new System.Drawing.Size(554, 316);
            this.rtbSqlQuery.TabIndex = 16;
            this.rtbSqlQuery.Text = "";
            // 
            // btnGenerateQueryTable
            // 
            this.btnGenerateQueryTable.Location = new System.Drawing.Point(484, 9);
            this.btnGenerateQueryTable.Name = "btnGenerateQueryTable";
            this.btnGenerateQueryTable.Size = new System.Drawing.Size(75, 55);
            this.btnGenerateQueryTable.TabIndex = 15;
            this.btnGenerateQueryTable.Text = "Generate query table";
            this.btnGenerateQueryTable.UseVisualStyleBackColor = true;
            this.btnGenerateQueryTable.Click += new System.EventHandler(this.btnGenerateQueryTable_Click);
            // 
            // lblObject
            // 
            this.lblObject.AutoSize = true;
            this.lblObject.Location = new System.Drawing.Point(230, 46);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(72, 13);
            this.lblObject.TabIndex = 23;
            this.lblObject.Text = "Object Name:";
            // 
            // cbObjectNames
            // 
            this.cbObjectNames.FormattingEnabled = true;
            this.cbObjectNames.Location = new System.Drawing.Point(305, 43);
            this.cbObjectNames.Name = "cbObjectNames";
            this.cbObjectNames.Size = new System.Drawing.Size(173, 21);
            this.cbObjectNames.TabIndex = 14;
            // 
            // cbObjectTypes
            // 
            this.cbObjectTypes.FormattingEnabled = true;
            this.cbObjectTypes.Location = new System.Drawing.Point(86, 43);
            this.cbObjectTypes.Name = "cbObjectTypes";
            this.cbObjectTypes.Size = new System.Drawing.Size(138, 21);
            this.cbObjectTypes.TabIndex = 13;
            this.cbObjectTypes.SelectedIndexChanged += new System.EventHandler(this.cbObjectTypes_SelectedIndexChanged);
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Location = new System.Drawing.Point(12, 46);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(68, 13);
            this.lblObjectType.TabIndex = 22;
            this.lblObjectType.Text = "Object Type:";
            // 
            // lblServerAndDataBase
            // 
            this.lblServerAndDataBase.AutoSize = true;
            this.lblServerAndDataBase.Location = new System.Drawing.Point(129, 9);
            this.lblServerAndDataBase.Name = "lblServerAndDataBase";
            this.lblServerAndDataBase.Size = new System.Drawing.Size(10, 13);
            this.lblServerAndDataBase.TabIndex = 21;
            this.lblServerAndDataBase.Text = ".";
            // 
            // lblServerAndDataBaseInfo
            // 
            this.lblServerAndDataBaseInfo.AutoSize = true;
            this.lblServerAndDataBaseInfo.Location = new System.Drawing.Point(12, 9);
            this.lblServerAndDataBaseInfo.Name = "lblServerAndDataBaseInfo";
            this.lblServerAndDataBaseInfo.Size = new System.Drawing.Size(111, 13);
            this.lblServerAndDataBaseInfo.TabIndex = 20;
            this.lblServerAndDataBaseInfo.Text = "Server and Database:";
            // 
            // ExporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 452);
            this.Controls.Add(this.chbOpenFile);
            this.Controls.Add(this.lblSaveToPath);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.rtbSqlQuery);
            this.Controls.Add(this.btnGenerateQueryTable);
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.cbObjectNames);
            this.Controls.Add(this.cbObjectTypes);
            this.Controls.Add(this.lblObjectType);
            this.Controls.Add(this.lblServerAndDataBase);
            this.Controls.Add(this.lblServerAndDataBaseInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExporterForm";
            this.Text = "ExporterForm";
            this.Load += new System.EventHandler(this.ExporterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbOpenFile;
        private System.Windows.Forms.Label lblSaveToPath;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RichTextBox rtbSqlQuery;
        private System.Windows.Forms.Button btnGenerateQueryTable;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.ComboBox cbObjectNames;
        private System.Windows.Forms.ComboBox cbObjectTypes;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.Label lblServerAndDataBase;
        private System.Windows.Forms.Label lblServerAndDataBaseInfo;
    }
}