namespace WindowsFormsTestApplication
{
    partial class ProcessesMainForm
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.lvcName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvcID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(127, 407);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start/Stop";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(276, 407);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // lvProcesses
            // 
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcName,
            this.lvcID});
            this.lvProcesses.Location = new System.Drawing.Point(12, 13);
            this.lvProcesses.MultiSelect = false;
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(339, 388);
            this.lvProcesses.TabIndex = 2;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            this.lvProcesses.SelectedIndexChanged += new System.EventHandler(this.lvProcesses_SelectedIndexChanged);
            this.lvProcesses.DoubleClick += new System.EventHandler(this.lvProcesses_DoubleClick);
            // 
            // lvcName
            // 
            this.lvcName.Text = "Name";
            this.lvcName.Width = 244;
            // 
            // lvcID
            // 
            this.lvcID.Text = "Process ID";
            this.lvcID.Width = 90;
            // 
            // ProcessesMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 436);
            this.Controls.Add(this.lvProcesses);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnStartStop);
            this.MaximumSize = new System.Drawing.Size(375, 474);
            this.MinimumSize = new System.Drawing.Size(375, 474);
            this.Name = "ProcessesMainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Processes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.ListView lvProcesses;
        private System.Windows.Forms.ColumnHeader lvcName;
        private System.Windows.Forms.ColumnHeader lvcID;
    }
}

