namespace User
{
    partial class ConsumerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subscriptionStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxCritical = new System.Windows.Forms.CheckBox();
            this.cbxNormal = new System.Windows.Forms.CheckBox();
            this.cbxWarning = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listMeasures = new System.Windows.Forms.ListView();
            this.Timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.subscriptionStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // subscriptionStatus
            // 
            this.subscriptionStatus.AutoSize = true;
            this.subscriptionStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.subscriptionStatus.Location = new System.Drawing.Point(223, 78);
            this.subscriptionStatus.Name = "subscriptionStatus";
            this.subscriptionStatus.Size = new System.Drawing.Size(78, 13);
            this.subscriptionStatus.TabIndex = 9;
            this.subscriptionStatus.Text = "Not subscribed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxCritical);
            this.groupBox3.Controls.Add(this.cbxNormal);
            this.groupBox3.Controls.Add(this.cbxWarning);
            this.groupBox3.Location = new System.Drawing.Point(9, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 100);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Subscriptions";
            // 
            // cbxCritical
            // 
            this.cbxCritical.AutoSize = true;
            this.cbxCritical.Location = new System.Drawing.Point(6, 68);
            this.cbxCritical.Name = "cbxCritical";
            this.cbxCritical.Size = new System.Drawing.Size(57, 17);
            this.cbxCritical.TabIndex = 5;
            this.cbxCritical.Text = "Critical";
            this.cbxCritical.UseVisualStyleBackColor = true;
            this.cbxCritical.CheckStateChanged += new System.EventHandler(this.cbxCritical_CheckStateChanged);
            // 
            // cbxNormal
            // 
            this.cbxNormal.AutoSize = true;
            this.cbxNormal.Location = new System.Drawing.Point(6, 20);
            this.cbxNormal.Name = "cbxNormal";
            this.cbxNormal.Size = new System.Drawing.Size(59, 17);
            this.cbxNormal.TabIndex = 2;
            this.cbxNormal.Text = "Normal";
            this.cbxNormal.UseVisualStyleBackColor = true;
            this.cbxNormal.CheckStateChanged += new System.EventHandler(this.cbxNormal_CheckStateChanged);
            // 
            // cbxWarning
            // 
            this.cbxWarning.AutoSize = true;
            this.cbxWarning.Location = new System.Drawing.Point(6, 45);
            this.cbxWarning.Name = "cbxWarning";
            this.cbxWarning.Size = new System.Drawing.Size(66, 17);
            this.cbxWarning.TabIndex = 4;
            this.cbxWarning.Text = "Warning";
            this.cbxWarning.UseVisualStyleBackColor = true;
            this.cbxWarning.CheckStateChanged += new System.EventHandler(this.cbxWarning_CheckStateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "If you wish to change subscription stop listening. Change subscriptions and press" +
    " Start again.";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(364, 193);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(445, 193);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Check types of alerts you with to subscribe to and press start to start consuming" +
    " received values.";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listMeasures);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Location = new System.Drawing.Point(12, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 295);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Received subscription alerts";
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
            this.listMeasures.Size = new System.Drawing.Size(511, 241);
            this.listMeasures.TabIndex = 3;
            this.listMeasures.UseCompatibleStateImageBehavior = false;
            this.listMeasures.View = System.Windows.Forms.View.Details;
            // 
            // Timestamp
            // 
            this.Timestamp.Text = "Timestamp";
            this.Timestamp.Width = 163;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 164;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 114;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(445, 266);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ConsumerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 547);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(569, 586);
            this.Name = "ConsumerForm";
            this.Text = "Consumer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConsumerForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxCritical;
        private System.Windows.Forms.CheckBox cbxWarning;
        private System.Windows.Forms.CheckBox cbxNormal;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listMeasures;
        private System.Windows.Forms.ColumnHeader Timestamp;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label subscriptionStatus;
        private System.Windows.Forms.Label label3;
    }
}