namespace GCDAll
{
    partial class GCDAll
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
            this.components = new System.ComponentModel.Container();
            this.PpuFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FileTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Temperature = new System.Windows.Forms.CheckBox();
            this.Precipitation = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.FutScenarioChk = new System.Windows.Forms.CheckedListBox();
            this.FutModelChk = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.baseObserve = new System.Windows.Forms.CheckBox();
            this.observeDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.FutEndDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.FutStartDate = new System.Windows.Forms.DateTimePicker();
            this.baseCru = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.BaseEndDate = new System.Windows.Forms.DateTimePicker();
            this.label220 = new System.Windows.Forms.Label();
            this.ScenarioChk = new System.Windows.Forms.CheckedListBox();
            this.BaseStartDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.ModelChk = new System.Windows.Forms.CheckedListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.OutputAnomaly = new System.Windows.Forms.Button();
            this.RunAnomaly = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PpuFileBtn
            // 
            this.PpuFileBtn.Location = new System.Drawing.Point(651, 21);
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
            this.FileTxt.Location = new System.Drawing.Point(156, 23);
            this.FileTxt.Name = "FileTxt";
            this.FileTxt.Size = new System.Drawing.Size(489, 20);
            this.FileTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(5, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Global Climate Models (GCMs):";
            // 
            // Temperature
            // 
            this.Temperature.AutoSize = true;
            this.Temperature.Location = new System.Drawing.Point(265, 341);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(86, 17);
            this.Temperature.TabIndex = 19;
            this.Temperature.Text = "Temperature";
            this.Temperature.UseVisualStyleBackColor = true;
            // 
            // Precipitation
            // 
            this.Precipitation.AutoSize = true;
            this.Precipitation.Location = new System.Drawing.Point(162, 341);
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
            this.label4.Location = new System.Drawing.Point(9, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Climate Variables:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.Temperature);
            this.groupBox1.Controls.Add(this.OutputAnomaly);
            this.groupBox1.Controls.Add(this.Precipitation);
            this.groupBox1.Controls.Add(this.RunAnomaly);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PpuFileBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FileTxt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 435);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculate Longterm Averages and Anomalies";
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label37.Location = new System.Drawing.Point(3, 106);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(152, 29);
            this.label37.TabIndex = 68;
            this.label37.Text = "Representative Concentration Pathways (RCPs):";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(11, 373);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 23);
            this.panel1.TabIndex = 69;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(381, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "or";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.radioButton2.Location = new System.Drawing.Point(419, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton2.Size = new System.Drawing.Size(108, 17);
            this.radioButton2.TabIndex = 58;
            this.radioButton2.Text = "ObservedPosition";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.radioButton1.Location = new System.Drawing.Point(259, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton1.Size = new System.Drawing.Size(97, 17);
            this.radioButton1.TabIndex = 57;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "PositionRecord";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(3, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Which of the database table is being used?";
            // 
            // FutScenarioChk
            // 
            this.FutScenarioChk.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.FutScenarioChk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FutScenarioChk.CheckOnClick = true;
            this.FutScenarioChk.FormattingEnabled = true;
            this.FutScenarioChk.Items.AddRange(new object[] {
            "Scenario1",
            "Scenario2",
            "Scenario3",
            "Scenario4",
            "Historical"});
            this.FutScenarioChk.Location = new System.Drawing.Point(157, 89);
            this.FutScenarioChk.MultiColumn = true;
            this.FutScenarioChk.Name = "FutScenarioChk";
            this.FutScenarioChk.Size = new System.Drawing.Size(567, 15);
            this.FutScenarioChk.TabIndex = 68;
            // 
            // FutModelChk
            // 
            this.FutModelChk.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.FutModelChk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FutModelChk.CheckOnClick = true;
            this.FutModelChk.FormattingEnabled = true;
            this.FutModelChk.Items.AddRange(new object[] {
            "GCM1",
            "GCM2",
            "GCM3",
            "GCM4",
            "GCM5"});
            this.FutModelChk.Location = new System.Drawing.Point(157, 59);
            this.FutModelChk.MultiColumn = true;
            this.FutModelChk.Name = "FutModelChk";
            this.FutModelChk.Size = new System.Drawing.Size(581, 15);
            this.FutModelChk.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(6, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 33);
            this.label7.TabIndex = 65;
            this.label7.Text = "Global Climate Models (GCMs):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.baseObserve);
            this.groupBox2.Controls.Add(this.observeDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(259, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 38);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            // 
            // baseObserve
            // 
            this.baseObserve.AutoSize = true;
            this.baseObserve.Location = new System.Drawing.Point(14, 12);
            this.baseObserve.Name = "baseObserve";
            this.baseObserve.Size = new System.Drawing.Size(94, 17);
            this.baseObserve.TabIndex = 61;
            this.baseObserve.Text = "ObservedUser";
            this.baseObserve.UseVisualStyleBackColor = true;
            this.baseObserve.CheckedChanged += new System.EventHandler(this.baseObserve_CheckedChanged_1);
            // 
            // observeDate
            // 
            this.observeDate.Location = new System.Drawing.Point(222, 12);
            this.observeDate.Name = "observeDate";
            this.observeDate.Size = new System.Drawing.Size(201, 20);
            this.observeDate.TabIndex = 63;
            this.observeDate.Value = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.observeDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "FileStartDate :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // FutEndDate
            // 
            this.FutEndDate.Location = new System.Drawing.Point(475, 23);
            this.FutEndDate.Name = "FutEndDate";
            this.FutEndDate.Size = new System.Drawing.Size(200, 20);
            this.FutEndDate.TabIndex = 58;
            this.FutEndDate.Value = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(414, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "EndDate :";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // FutStartDate
            // 
            this.FutStartDate.Location = new System.Drawing.Point(200, 23);
            this.FutStartDate.Name = "FutStartDate";
            this.FutStartDate.Size = new System.Drawing.Size(201, 20);
            this.FutStartDate.TabIndex = 56;
            this.FutStartDate.Value = new System.DateTime(2030, 1, 1, 0, 0, 0, 0);
            // 
            // baseCru
            // 
            this.baseCru.AutoSize = true;
            this.baseCru.Location = new System.Drawing.Point(152, 22);
            this.baseCru.Name = "baseCru";
            this.baseCru.Size = new System.Drawing.Size(88, 17);
            this.baseCru.TabIndex = 59;
            this.baseCru.Text = "ObservedCru";
            this.baseCru.UseVisualStyleBackColor = true;
            this.baseCru.CheckedChanged += new System.EventHandler(this.baseCru_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(140, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 55;
            this.label19.Text = "StartDate :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label20.Location = new System.Drawing.Point(5, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 54;
            this.label20.Text = "Future Period:";
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(5, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 29);
            this.label15.TabIndex = 52;
            this.label15.Text = "Observed Climate Data (Base) :";
            // 
            // BaseEndDate
            // 
            this.BaseEndDate.Location = new System.Drawing.Point(481, 51);
            this.BaseEndDate.Name = "BaseEndDate";
            this.BaseEndDate.Size = new System.Drawing.Size(200, 20);
            this.BaseEndDate.TabIndex = 51;
            this.BaseEndDate.Value = new System.DateTime(2012, 12, 31, 0, 0, 0, 0);
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(420, 57);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(55, 13);
            this.label220.TabIndex = 50;
            this.label220.Text = "EndDate :";
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
            "Scenario4",
            "Historical"});
            this.ScenarioChk.Location = new System.Drawing.Point(156, 112);
            this.ScenarioChk.MultiColumn = true;
            this.ScenarioChk.Name = "ScenarioChk";
            this.ScenarioChk.Size = new System.Drawing.Size(557, 15);
            this.ScenarioChk.TabIndex = 50;
            this.ScenarioChk.SelectedIndexChanged += new System.EventHandler(this.ScenarioChk_SelectedIndexChanged);
            this.ScenarioChk.MouseHover += new System.EventHandler(this.ScenarioChk_MouseHover);
            this.ScenarioChk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScenarioChk_MouseMove);
            // 
            // BaseStartDate
            // 
            this.BaseStartDate.Location = new System.Drawing.Point(200, 53);
            this.BaseStartDate.Name = "BaseStartDate";
            this.BaseStartDate.Size = new System.Drawing.Size(201, 20);
            this.BaseStartDate.TabIndex = 49;
            this.BaseStartDate.Value = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(140, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 48;
            this.label16.Text = "StartDate :";
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
            this.ModelChk.Location = new System.Drawing.Point(156, 82);
            this.ModelChk.MultiColumn = true;
            this.ModelChk.Name = "ModelChk";
            this.ModelChk.Size = new System.Drawing.Size(557, 15);
            this.ModelChk.TabIndex = 49;
            this.ModelChk.MouseHover += new System.EventHandler(this.ModelChk_MouseHover);
            this.ModelChk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ModelChk_MouseMove);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label17.Location = new System.Drawing.Point(5, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "Base Period:";
            // 
            // OutputAnomaly
            // 
            this.OutputAnomaly.Location = new System.Drawing.Point(716, 388);
            this.OutputAnomaly.Name = "OutputAnomaly";
            this.OutputAnomaly.Size = new System.Drawing.Size(85, 38);
            this.OutputAnomaly.TabIndex = 53;
            this.OutputAnomaly.Text = "Browse Output";
            this.OutputAnomaly.UseVisualStyleBackColor = true;
            this.OutputAnomaly.Click += new System.EventHandler(this.OutputAnomaly_Click);
            // 
            // RunAnomaly
            // 
            this.RunAnomaly.BackColor = System.Drawing.Color.PaleGreen;
            this.RunAnomaly.Location = new System.Drawing.Point(716, 344);
            this.RunAnomaly.Name = "RunAnomaly";
            this.RunAnomaly.Size = new System.Drawing.Size(85, 38);
            this.RunAnomaly.TabIndex = 52;
            this.RunAnomaly.Text = "Run";
            this.RunAnomaly.UseVisualStyleBackColor = false;
            this.RunAnomaly.Click += new System.EventHandler(this.RunAnomaly_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(3, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 29);
            this.label3.TabIndex = 70;
            this.label3.Text = "Representative Concentration Pathways (RCPs):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.FutScenarioChk);
            this.groupBox3.Controls.Add(this.FutModelChk);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.FutEndDate);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.FutStartDate);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Location = new System.Drawing.Point(3, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(823, 133);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.baseCru);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.BaseEndDate);
            this.groupBox4.Controls.Add(this.label220);
            this.groupBox4.Controls.Add(this.ScenarioChk);
            this.groupBox4.Controls.Add(this.BaseStartDate);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.ModelChk);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(3, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(820, 144);
            this.groupBox4.TabIndex = 72;
            this.groupBox4.TabStop = false;
            // 
            // GCDAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 459);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "GCDAll";
            this.Text = "Global Climate Data Management (GCDM)";
            this.Load += new System.EventHandler(this.GCD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PpuFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Temperature;
        private System.Windows.Forms.CheckBox Precipitation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker FutEndDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker FutStartDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button OutputAnomaly;
        private System.Windows.Forms.Button RunAnomaly;
        private System.Windows.Forms.CheckedListBox ModelChk;
        private System.Windows.Forms.CheckedListBox ScenarioChk;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox baseCru;
        private System.Windows.Forms.CheckBox baseObserve;
        private System.Windows.Forms.DateTimePicker observeDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker BaseEndDate;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.DateTimePicker BaseStartDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox FutScenarioChk;
        private System.Windows.Forms.CheckedListBox FutModelChk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

