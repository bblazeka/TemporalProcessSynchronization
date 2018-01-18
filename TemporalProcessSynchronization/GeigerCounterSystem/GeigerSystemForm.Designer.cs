namespace GeigerCounterSystem
{
    partial class GeigerSystemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeigerSystemForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.gbxCollectionManager = new System.Windows.Forms.GroupBox();
            this.collectionStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbxSentData = new System.Windows.Forms.GroupBox();
            this.listMeasures = new System.Windows.Forms.ListView();
            this.Timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClearList = new System.Windows.Forms.Button();
            this.gbxCollectionManager.SuspendLayout();
            this.gbxSentData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(9, 81);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbxCollectionManager
            // 
            this.gbxCollectionManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCollectionManager.Controls.Add(this.collectionStatus);
            this.gbxCollectionManager.Controls.Add(this.label2);
            this.gbxCollectionManager.Controls.Add(this.label1);
            this.gbxCollectionManager.Controls.Add(this.btnStop);
            this.gbxCollectionManager.Controls.Add(this.btnStart);
            this.gbxCollectionManager.Location = new System.Drawing.Point(12, 12);
            this.gbxCollectionManager.Name = "gbxCollectionManager";
            this.gbxCollectionManager.Size = new System.Drawing.Size(640, 116);
            this.gbxCollectionManager.TabIndex = 1;
            this.gbxCollectionManager.TabStop = false;
            this.gbxCollectionManager.Text = "Collection";
            // 
            // collectionStatus
            // 
            this.collectionStatus.AutoSize = true;
            this.collectionStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.collectionStatus.Location = new System.Drawing.Point(392, 25);
            this.collectionStatus.Name = "collectionStatus";
            this.collectionStatus.Size = new System.Drawing.Size(47, 13);
            this.collectionStatus.TabIndex = 5;
            this.collectionStatus.Text = "Stopped";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Collection status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Press Start to start collecting radiation measures.\r\nCollected measures will be d" +
    "isplayed in list below.\r\nIf you wish to stop measuring data, press Stop button.";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(90, 81);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // gbxSentData
            // 
            this.gbxSentData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSentData.Controls.Add(this.listMeasures);
            this.gbxSentData.Controls.Add(this.btnClearList);
            this.gbxSentData.Location = new System.Drawing.Point(12, 134);
            this.gbxSentData.Name = "gbxSentData";
            this.gbxSentData.Size = new System.Drawing.Size(640, 362);
            this.gbxSentData.TabIndex = 3;
            this.gbxSentData.TabStop = false;
            this.gbxSentData.Text = "Sent data";
            // 
            // listMeasures
            // 
            this.listMeasures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMeasures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Timestamp,
            this.Value,
            this.Status});
            this.listMeasures.Location = new System.Drawing.Point(9, 19);
            this.listMeasures.Name = "listMeasures";
            this.listMeasures.Size = new System.Drawing.Size(625, 308);
            this.listMeasures.TabIndex = 1;
            this.listMeasures.UseCompatibleStateImageBehavior = false;
            this.listMeasures.View = System.Windows.Forms.View.Details;
            // 
            // Timestamp
            // 
            this.Timestamp.Text = "Timestamp";
            this.Timestamp.Width = 247;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 203;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 155;
            // 
            // btnClearList
            // 
            this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearList.Location = new System.Drawing.Point(559, 333);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 0;
            this.btnClearList.Text = "Clear";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // GeigerSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 508);
            this.Controls.Add(this.gbxSentData);
            this.Controls.Add(this.gbxCollectionManager);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(612, 504);
            this.Name = "GeigerSystemForm";
            this.Text = "Geiger System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeigerSystemForm_FormClosed);
            this.gbxCollectionManager.ResumeLayout(false);
            this.gbxCollectionManager.PerformLayout();
            this.gbxSentData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbxCollectionManager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox gbxSentData;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Label collectionStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listMeasures;
        private System.Windows.Forms.ColumnHeader Timestamp;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ColumnHeader Status;
    }
}