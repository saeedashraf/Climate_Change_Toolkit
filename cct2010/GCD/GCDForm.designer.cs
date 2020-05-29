namespace GCD
{
    partial class GCD
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
            this.PpuFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FileTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Temperature = new System.Windows.Forms.CheckBox();
            this.Precipitation = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RunGcd = new System.Windows.Forms.Button();
            this.OutputGcd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CruModel = new System.Windows.Forms.CheckBox();
            this.ScenarioChk = new System.Windows.Forms.CheckedListBox();
            this.ModelChk = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.baseCru = new System.Windows.Forms.CheckBox();
            this.FutEndDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.FutStartDate = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.OutputAnomaly = new System.Windows.Forms.Button();
            this.RunAnomaly = new System.Windows.Forms.Button();
            this.BaseEndDate = new System.Windows.Forms.DateTimePicker();
            this.label220 = new System.Windows.Forms.Label();
            this.BaseStartDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PpuFileBtn
            // 
            this.PpuFileBtn.Location = new System.Drawing.Point(615, 21);
            this.PpuFileBtn.Name = "PpuFileBtn";
            this.PpuFileBtn.Size = new System.Drawing.Size(53, 24);
            this.PpuFileBtn.TabIndex = 5;
            this.PpuFileBtn.Text = "browse";
            this.PpuFileBtn.UseVisualStyleBackColor = true;
            this.PpuFileBtn.Click += new System.EventHandler(this.PpuFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input Data :";
            // 
            // FileTxt
            // 
            this.FileTxt.Location = new System.Drawing.Point(120, 23);
            this.FileTxt.Name = "FileTxt";
            this.FileTxt.Size = new System.Drawing.Size(489, 20);
            this.FileTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(8, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Future Climate Models:";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(8, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Carbon Emission Scenarios:";
            // 
            // Temperature
            // 
            this.Temperature.AutoSize = true;
            this.Temperature.Location = new System.Drawing.Point(240, 150);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(86, 17);
            this.Temperature.TabIndex = 19;
            this.Temperature.Text = "Temperature";
            this.Temperature.UseVisualStyleBackColor = true;
            // 
            // Precipitation
            // 
            this.Precipitation.AutoSize = true;
            this.Precipitation.Location = new System.Drawing.Point(121, 150);
            this.Precipitation.Name = "Precipitation";
            this.Precipitation.Size = new System.Drawing.Size(84, 17);
            this.Precipitation.TabIndex = 18;
            this.Precipitation.Text = "Precipitation";
            this.Precipitation.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(8, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Climate Variables:";
            // 
            // RunGcd
            // 
            this.RunGcd.BackColor = System.Drawing.Color.PaleGreen;
            this.RunGcd.Location = new System.Drawing.Point(749, 169);
            this.RunGcd.Name = "RunGcd";
            this.RunGcd.Size = new System.Drawing.Size(75, 36);
            this.RunGcd.TabIndex = 42;
            this.RunGcd.Text = "Run";
            this.RunGcd.UseVisualStyleBackColor = false;
            this.RunGcd.Click += new System.EventHandler(this.RunGcd_Click);
            // 
            // OutputGcd
            // 
            this.OutputGcd.Location = new System.Drawing.Point(749, 127);
            this.OutputGcd.Name = "OutputGcd";
            this.OutputGcd.Size = new System.Drawing.Size(75, 38);
            this.OutputGcd.TabIndex = 43;
            this.OutputGcd.Text = "Browse Output";
            this.OutputGcd.UseVisualStyleBackColor = true;
            this.OutputGcd.Click += new System.EventHandler(this.OutputGcd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.OutputGcd);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.CruModel);
            this.groupBox1.Controls.Add(this.ScenarioChk);
            this.groupBox1.Controls.Add(this.ModelChk);
            this.groupBox1.Controls.Add(this.RunGcd);
            this.groupBox1.Controls.Add(this.Temperature);
            this.groupBox1.Controls.Add(this.Precipitation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PpuFileBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FileTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 212);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculate monthly and annually averages";
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(8, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 29);
            this.label15.TabIndex = 52;
            this.label15.Text = "Historic Climate Model:";
            // 
            // CruModel
            // 
            this.CruModel.AutoSize = true;
            this.CruModel.Location = new System.Drawing.Point(120, 55);
            this.CruModel.Name = "CruModel";
            this.CruModel.Size = new System.Drawing.Size(84, 17);
            this.CruModel.TabIndex = 51;
            this.CruModel.Text = "HistoricData";
            this.CruModel.UseVisualStyleBackColor = true;
            this.CruModel.CheckedChanged += new System.EventHandler(this.CruModel_CheckedChanged);
            // 
            // ScenarioChk
            // 
            this.ScenarioChk.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ScenarioChk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScenarioChk.CheckOnClick = true;
            this.ScenarioChk.FormattingEnabled = true;
            this.ScenarioChk.Items.AddRange(new object[] {
            "Scenario1",
            "Scenario2",
            "Scenario3",
            "Scenario4"});
            this.ScenarioChk.Location = new System.Drawing.Point(120, 116);
            this.ScenarioChk.MultiColumn = true;
            this.ScenarioChk.Name = "ScenarioChk";
            this.ScenarioChk.Size = new System.Drawing.Size(645, 15);
            this.ScenarioChk.TabIndex = 50;
            this.ScenarioChk.SelectedIndexChanged += new System.EventHandler(this.ScenarioChk_SelectedIndexChanged);
            // 
            // ModelChk
            // 
            this.ModelChk.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ModelChk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModelChk.CheckOnClick = true;
            this.ModelChk.FormattingEnabled = true;
            this.ModelChk.Items.AddRange(new object[] {
            "GCM1",
            "GCM2",
            "GCM3",
            "GCM4",
            "GCM5"});
            this.ModelChk.Location = new System.Drawing.Point(119, 84);
            this.ModelChk.MultiColumn = true;
            this.ModelChk.Name = "ModelChk";
            this.ModelChk.Size = new System.Drawing.Size(734, 15);
            this.ModelChk.TabIndex = 49;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.baseCru);
            this.groupBox2.Controls.Add(this.FutEndDate);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.FutStartDate);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.OutputAnomaly);
            this.groupBox2.Controls.Add(this.RunAnomaly);
            this.groupBox2.Controls.Add(this.BaseEndDate);
            this.groupBox2.Controls.Add(this.label220);
            this.groupBox2.Controls.Add(this.BaseStartDate);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(833, 115);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calculate Longterm Averages and Anomalies";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label21.Location = new System.Drawing.Point(8, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(143, 13);
            this.label21.TabIndex = 60;
            this.label21.Text = "Historic Climate Data (base) :";
            // 
            // baseCru
            // 
            this.baseCru.AutoSize = true;
            this.baseCru.Location = new System.Drawing.Point(156, 20);
            this.baseCru.Name = "baseCru";
            this.baseCru.Size = new System.Drawing.Size(84, 17);
            this.baseCru.TabIndex = 59;
            this.baseCru.Text = "HistoricData";
            this.baseCru.UseVisualStyleBackColor = true;
            // 
            // FutEndDate
            // 
            this.FutEndDate.Location = new System.Drawing.Point(437, 66);
            this.FutEndDate.Name = "FutEndDate";
            this.FutEndDate.Size = new System.Drawing.Size(200, 20);
            this.FutEndDate.TabIndex = 58;
            this.FutEndDate.Value = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(376, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "EndDate :";
            // 
            // FutStartDate
            // 
            this.FutStartDate.Location = new System.Drawing.Point(156, 68);
            this.FutStartDate.Name = "FutStartDate";
            this.FutStartDate.Size = new System.Drawing.Size(201, 20);
            this.FutStartDate.TabIndex = 56;
            this.FutStartDate.Value = new System.DateTime(2030, 1, 1, 0, 0, 0, 0);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(96, 72);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 55;
            this.label19.Text = "StartDate :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label20.Location = new System.Drawing.Point(8, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 54;
            this.label20.Text = "Future Period:";
            // 
            // OutputAnomaly
            // 
            this.OutputAnomaly.Location = new System.Drawing.Point(749, 25);
            this.OutputAnomaly.Name = "OutputAnomaly";
            this.OutputAnomaly.Size = new System.Drawing.Size(75, 38);
            this.OutputAnomaly.TabIndex = 53;
            this.OutputAnomaly.Text = "Browse Output";
            this.OutputAnomaly.UseVisualStyleBackColor = true;
            this.OutputAnomaly.Click += new System.EventHandler(this.OutputAnomaly_Click);
            // 
            // RunAnomaly
            // 
            this.RunAnomaly.BackColor = System.Drawing.Color.PaleGreen;
            this.RunAnomaly.Location = new System.Drawing.Point(749, 69);
            this.RunAnomaly.Name = "RunAnomaly";
            this.RunAnomaly.Size = new System.Drawing.Size(75, 38);
            this.RunAnomaly.TabIndex = 52;
            this.RunAnomaly.Text = "Run";
            this.RunAnomaly.UseVisualStyleBackColor = false;
            this.RunAnomaly.Click += new System.EventHandler(this.RunAnomaly_Click);
            // 
            // BaseEndDate
            // 
            this.BaseEndDate.Location = new System.Drawing.Point(437, 40);
            this.BaseEndDate.Name = "BaseEndDate";
            this.BaseEndDate.Size = new System.Drawing.Size(200, 20);
            this.BaseEndDate.TabIndex = 51;
            this.BaseEndDate.Value = new System.DateTime(2012, 12, 31, 0, 0, 0, 0);
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(376, 46);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(55, 13);
            this.label220.TabIndex = 50;
            this.label220.Text = "EndDate :";
            // 
            // BaseStartDate
            // 
            this.BaseStartDate.Location = new System.Drawing.Point(156, 42);
            this.BaseStartDate.Name = "BaseStartDate";
            this.BaseStartDate.Size = new System.Drawing.Size(201, 20);
            this.BaseStartDate.TabIndex = 49;
            this.BaseStartDate.Value = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(96, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 48;
            this.label16.Text = "StartDate :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label17.Location = new System.Drawing.Point(8, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "Base Period:";
            // 
            // GCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 356);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "GCD";
            this.Text = "Global Climate Data Management (GCDM)";
            this.Load += new System.EventHandler(this.GCD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PpuFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Temperature;
        private System.Windows.Forms.CheckBox Precipitation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RunGcd;
        private System.Windows.Forms.Button OutputGcd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker FutEndDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker FutStartDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button OutputAnomaly;
        private System.Windows.Forms.Button RunAnomaly;
        private System.Windows.Forms.DateTimePicker BaseEndDate;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.DateTimePicker BaseStartDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckedListBox ModelChk;
        private System.Windows.Forms.CheckedListBox ScenarioChk;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox CruModel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox baseCru;
    }
}

