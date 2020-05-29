namespace CCT
{
    partial class CctMain
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LatFrom = new System.Windows.Forms.TextBox();
            this.LatTo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LongTo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LongFrom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.EntirePeriod = new System.Windows.Forms.RadioButton();
            this.SelectedPeriod = new System.Windows.Forms.RadioButton();
            this.SimStartDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.SimEndDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.OutputGcd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OutputBrows = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.OutputTxt = new System.Windows.Forms.TextBox();
            this.twoBtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.CruModel = new System.Windows.Forms.CheckBox();
            this.ScenarioChk = new System.Windows.Forms.CheckedListBox();
            this.ModelChk = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SelectedArea = new System.Windows.Forms.RadioButton();
            this.EntireArea = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PpuFileBtn
            // 
            this.PpuFileBtn.Location = new System.Drawing.Point(643, 20);
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
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Main Database Folder :";
            // 
            // FileTxt
            // 
            this.FileTxt.Location = new System.Drawing.Point(162, 23);
            this.FileTxt.Name = "FileTxt";
            this.FileTxt.Size = new System.Drawing.Size(455, 20);
            this.FileTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Future Climate Models:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Carbon Emission Scenarios:";
            // 
            // Temperature
            // 
            this.Temperature.AutoSize = true;
            this.Temperature.Location = new System.Drawing.Point(283, 139);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(86, 17);
            this.Temperature.TabIndex = 19;
            this.Temperature.Text = "Temperature";
            this.Temperature.UseVisualStyleBackColor = true;
            // 
            // Precipitation
            // 
            this.Precipitation.AutoSize = true;
            this.Precipitation.Location = new System.Drawing.Point(163, 139);
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
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Cliamate Variables:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(9, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Spatial Extent to Extract:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(156, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "longitude:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(156, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Latitude:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "From:";
            // 
            // LatFrom
            // 
            this.LatFrom.Location = new System.Drawing.Point(257, 20);
            this.LatFrom.Name = "LatFrom";
            this.LatFrom.Size = new System.Drawing.Size(121, 20);
            this.LatFrom.TabIndex = 26;
            // 
            // LatTo
            // 
            this.LatTo.Location = new System.Drawing.Point(434, 20);
            this.LatTo.Name = "LatTo";
            this.LatTo.Size = new System.Drawing.Size(121, 20);
            this.LatTo.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(405, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "To:";
            // 
            // LongTo
            // 
            this.LongTo.Location = new System.Drawing.Point(434, 54);
            this.LongTo.Name = "LongTo";
            this.LongTo.Size = new System.Drawing.Size(121, 20);
            this.LongTo.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(405, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "To:";
            // 
            // LongFrom
            // 
            this.LongFrom.Location = new System.Drawing.Point(257, 54);
            this.LongFrom.Name = "LongFrom";
            this.LongFrom.Size = new System.Drawing.Size(121, 20);
            this.LongFrom.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(218, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "From:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label12.Location = new System.Drawing.Point(9, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Temporal Extent to Extract:";
            // 
            // EntirePeriod
            // 
            this.EntirePeriod.AutoSize = true;
            this.EntirePeriod.Checked = true;
            this.EntirePeriod.Location = new System.Drawing.Point(159, 8);
            this.EntirePeriod.Name = "EntirePeriod";
            this.EntirePeriod.Size = new System.Drawing.Size(82, 17);
            this.EntirePeriod.TabIndex = 36;
            this.EntirePeriod.TabStop = true;
            this.EntirePeriod.Text = "EntirePeriod";
            this.EntirePeriod.UseVisualStyleBackColor = true;
            // 
            // SelectedPeriod
            // 
            this.SelectedPeriod.AutoSize = true;
            this.SelectedPeriod.Location = new System.Drawing.Point(159, 31);
            this.SelectedPeriod.Name = "SelectedPeriod";
            this.SelectedPeriod.Size = new System.Drawing.Size(97, 17);
            this.SelectedPeriod.TabIndex = 37;
            this.SelectedPeriod.Text = "SelectedPeriod";
            this.SelectedPeriod.UseVisualStyleBackColor = true;
            // 
            // SimStartDate
            // 
            this.SimStartDate.Location = new System.Drawing.Point(437, 5);
            this.SimStartDate.Name = "SimStartDate";
            this.SimStartDate.Size = new System.Drawing.Size(201, 20);
            this.SimStartDate.TabIndex = 39;
            this.SimStartDate.Value = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(373, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "StartDate :";
            // 
            // SimEndDate
            // 
            this.SimEndDate.Location = new System.Drawing.Point(437, 31);
            this.SimEndDate.Name = "SimEndDate";
            this.SimEndDate.Size = new System.Drawing.Size(200, 20);
            this.SimEndDate.TabIndex = 41;
            this.SimEndDate.Value = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(376, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "EndDate :";
            // 
            // OutputGcd
            // 
            this.OutputGcd.Location = new System.Drawing.Point(750, 289);
            this.OutputGcd.Name = "OutputGcd";
            this.OutputGcd.Size = new System.Drawing.Size(75, 36);
            this.OutputGcd.TabIndex = 43;
            this.OutputGcd.Text = "Browse Output";
            this.OutputGcd.UseVisualStyleBackColor = true;
            this.OutputGcd.Click += new System.EventHandler(this.OutputGcd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.OutputBrows);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.OutputTxt);
            this.groupBox1.Controls.Add(this.twoBtn);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.CruModel);
            this.groupBox1.Controls.Add(this.ScenarioChk);
            this.groupBox1.Controls.Add(this.ModelChk);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.OutputGcd);
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
            this.groupBox1.Size = new System.Drawing.Size(833, 378);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Climate Data";
            // 
            // OutputBrows
            // 
            this.OutputBrows.Location = new System.Drawing.Point(597, 341);
            this.OutputBrows.Name = "OutputBrows";
            this.OutputBrows.Size = new System.Drawing.Size(53, 24);
            this.OutputBrows.TabIndex = 59;
            this.OutputBrows.Text = "browse";
            this.OutputBrows.UseVisualStyleBackColor = true;
            this.OutputBrows.Click += new System.EventHandler(this.OutputBrows_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label16.Location = new System.Drawing.Point(12, 346);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 13);
            this.label16.TabIndex = 58;
            this.label16.Text = "User Project Folder:";
            // 
            // OutputTxt
            // 
            this.OutputTxt.Location = new System.Drawing.Point(169, 343);
            this.OutputTxt.Name = "OutputTxt";
            this.OutputTxt.Size = new System.Drawing.Size(422, 20);
            this.OutputTxt.TabIndex = 57;
            // 
            // twoBtn
            // 
            this.twoBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.twoBtn.Location = new System.Drawing.Point(750, 331);
            this.twoBtn.Name = "twoBtn";
            this.twoBtn.Size = new System.Drawing.Size(75, 32);
            this.twoBtn.TabIndex = 56;
            this.twoBtn.Text = "Run";
            this.twoBtn.UseVisualStyleBackColor = false;
            this.twoBtn.Click += new System.EventHandler(this.twoBtn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(12, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "Historic Climate Data:";
            // 
            // CruModel
            // 
            this.CruModel.AutoSize = true;
            this.CruModel.Location = new System.Drawing.Point(162, 51);
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
            this.ScenarioChk.Location = new System.Drawing.Point(162, 110);
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
            this.ModelChk.Location = new System.Drawing.Point(162, 81);
            this.ModelChk.MultiColumn = true;
            this.ModelChk.Name = "ModelChk";
            this.ModelChk.Size = new System.Drawing.Size(734, 15);
            this.ModelChk.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SimEndDate);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.SimStartDate);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.SelectedPeriod);
            this.panel2.Controls.Add(this.EntirePeriod);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(3, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 59);
            this.panel2.TabIndex = 48;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SelectedArea);
            this.panel1.Controls.Add(this.EntireArea);
            this.panel1.Controls.Add(this.LongTo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.LongFrom);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.LatTo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.LatFrom);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(3, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 92);
            this.panel1.TabIndex = 47;
            // 
            // SelectedArea
            // 
            this.SelectedArea.AutoSize = true;
            this.SelectedArea.Checked = true;
            this.SelectedArea.Location = new System.Drawing.Point(280, 1);
            this.SelectedArea.Name = "SelectedArea";
            this.SelectedArea.Size = new System.Drawing.Size(89, 17);
            this.SelectedArea.TabIndex = 46;
            this.SelectedArea.TabStop = true;
            this.SelectedArea.Text = "SelectedArea";
            this.SelectedArea.UseVisualStyleBackColor = true;
            this.SelectedArea.Visible = false;
            // 
            // EntireArea
            // 
            this.EntireArea.AutoSize = true;
            this.EntireArea.Location = new System.Drawing.Point(159, 3);
            this.EntireArea.Name = "EntireArea";
            this.EntireArea.Size = new System.Drawing.Size(74, 17);
            this.EntireArea.TabIndex = 45;
            this.EntireArea.Text = "EntireArea";
            this.EntireArea.UseVisualStyleBackColor = true;
            this.EntireArea.Visible = false;
            // 
            // CctMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 398);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "CctMain";
            this.Text = "General Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox LatFrom;
        private System.Windows.Forms.TextBox LatTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox LongTo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox LongFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton EntirePeriod;
        private System.Windows.Forms.RadioButton SelectedPeriod;
        private System.Windows.Forms.DateTimePicker SimStartDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker SimEndDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button OutputGcd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SelectedArea;
        private System.Windows.Forms.RadioButton EntireArea;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox ModelChk;
        private System.Windows.Forms.CheckedListBox ScenarioChk;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox CruModel;
        private System.Windows.Forms.Button twoBtn;
        private System.Windows.Forms.Button OutputBrows;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox OutputTxt;
    }
}

