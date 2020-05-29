namespace Correction
{
    partial class CorrectionForm
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
            this.AnomalyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AnomalyTxt = new System.Windows.Forms.TextBox();
            this.MeasuredBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MeasuredTxt = new System.Windows.Forms.TextBox();
            this.FilesBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DirectFilesTxt = new System.Windows.Forms.TextBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.commentLbl = new System.Windows.Forms.Label();
            this.RatioRb = new System.Windows.Forms.RadioButton();
            this.PlusRb = new System.Windows.Forms.RadioButton();
            this.CruChk = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OutFilesBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.OutputTxt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CruModel = new System.Windows.Forms.CheckBox();
            this.ScenarioChk = new System.Windows.Forms.CheckedListBox();
            this.ModelChk = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ManualPanel = new System.Windows.Forms.Panel();
            this.Temperature = new System.Windows.Forms.CheckBox();
            this.Precipitation = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.PpuFileBtn = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.ManualFilesTxt = new System.Windows.Forms.TextBox();
            this.ManualRb = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DirectRb = new System.Windows.Forms.RadioButton();
            this.DirectPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OutputGcd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.ManualPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.DirectPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnomalyBtn
            // 
            this.AnomalyBtn.Location = new System.Drawing.Point(661, 244);
            this.AnomalyBtn.Name = "AnomalyBtn";
            this.AnomalyBtn.Size = new System.Drawing.Size(53, 24);
            this.AnomalyBtn.TabIndex = 8;
            this.AnomalyBtn.Text = "browse";
            this.AnomalyBtn.UseVisualStyleBackColor = true;
            this.AnomalyBtn.Click += new System.EventHandler(this.AnomalyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(19, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Future Longterm Statistics:";
            // 
            // AnomalyTxt
            // 
            this.AnomalyTxt.Location = new System.Drawing.Point(166, 247);
            this.AnomalyTxt.Name = "AnomalyTxt";
            this.AnomalyTxt.Size = new System.Drawing.Size(466, 20);
            this.AnomalyTxt.TabIndex = 6;
            // 
            // MeasuredBtn
            // 
            this.MeasuredBtn.Location = new System.Drawing.Point(661, 272);
            this.MeasuredBtn.Name = "MeasuredBtn";
            this.MeasuredBtn.Size = new System.Drawing.Size(53, 24);
            this.MeasuredBtn.TabIndex = 11;
            this.MeasuredBtn.Text = "browse";
            this.MeasuredBtn.UseVisualStyleBackColor = true;
            this.MeasuredBtn.Click += new System.EventHandler(this.MeasuredBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(19, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Historic Longterm Statistics:";
            // 
            // MeasuredTxt
            // 
            this.MeasuredTxt.Location = new System.Drawing.Point(166, 275);
            this.MeasuredTxt.Name = "MeasuredTxt";
            this.MeasuredTxt.Size = new System.Drawing.Size(466, 20);
            this.MeasuredTxt.TabIndex = 9;
            // 
            // FilesBtn
            // 
            this.FilesBtn.Location = new System.Drawing.Point(648, 8);
            this.FilesBtn.Name = "FilesBtn";
            this.FilesBtn.Size = new System.Drawing.Size(53, 24);
            this.FilesBtn.TabIndex = 14;
            this.FilesBtn.Text = "browse";
            this.FilesBtn.UseVisualStyleBackColor = true;
            this.FilesBtn.Click += new System.EventHandler(this.FilesBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Files Folder :";
            // 
            // DirectFilesTxt
            // 
            this.DirectFilesTxt.Location = new System.Drawing.Point(153, 11);
            this.DirectFilesTxt.Name = "DirectFilesTxt";
            this.DirectFilesTxt.Size = new System.Drawing.Size(466, 20);
            this.DirectFilesTxt.TabIndex = 12;
            // 
            // RunBtn
            // 
            this.RunBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.RunBtn.Location = new System.Drawing.Point(773, 305);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(67, 31);
            this.RunBtn.TabIndex = 15;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = false;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // commentLbl
            // 
            this.commentLbl.AutoSize = true;
            this.commentLbl.Location = new System.Drawing.Point(503, 407);
            this.commentLbl.Name = "commentLbl";
            this.commentLbl.Size = new System.Drawing.Size(0, 13);
            this.commentLbl.TabIndex = 16;
            // 
            // RatioRb
            // 
            this.RatioRb.AutoSize = true;
            this.RatioRb.Checked = true;
            this.RatioRb.Location = new System.Drawing.Point(11, 6);
            this.RatioRb.Name = "RatioRb";
            this.RatioRb.Size = new System.Drawing.Size(89, 17);
            this.RatioRb.TabIndex = 17;
            this.RatioRb.TabStop = true;
            this.RatioRb.Text = "Ratio Method";
            this.RatioRb.UseVisualStyleBackColor = true;
            // 
            // PlusRb
            // 
            this.PlusRb.AutoSize = true;
            this.PlusRb.Location = new System.Drawing.Point(152, 5);
            this.PlusRb.Name = "PlusRb";
            this.PlusRb.Size = new System.Drawing.Size(102, 17);
            this.PlusRb.TabIndex = 18;
            this.PlusRb.TabStop = true;
            this.PlusRb.Text = "Additive Method";
            this.PlusRb.UseVisualStyleBackColor = true;
            // 
            // CruChk
            // 
            this.CruChk.AutoSize = true;
            this.CruChk.Location = new System.Drawing.Point(457, 314);
            this.CruChk.Name = "CruChk";
            this.CruChk.Size = new System.Drawing.Size(41, 17);
            this.CruChk.TabIndex = 19;
            this.CruChk.Text = "cru";
            this.CruChk.UseVisualStyleBackColor = true;
            this.CruChk.Visible = false;
            this.CruChk.CheckedChanged += new System.EventHandler(this.CruChk_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(19, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Correction Method :";
            // 
            // OutFilesBtn
            // 
            this.OutFilesBtn.Location = new System.Drawing.Point(661, 218);
            this.OutFilesBtn.Name = "OutFilesBtn";
            this.OutFilesBtn.Size = new System.Drawing.Size(53, 24);
            this.OutFilesBtn.TabIndex = 23;
            this.OutFilesBtn.Text = "browse";
            this.OutFilesBtn.UseVisualStyleBackColor = true;
            this.OutFilesBtn.Visible = false;
            this.OutFilesBtn.Click += new System.EventHandler(this.OutFilesBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(19, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Output Folder : ";
            this.label5.Visible = false;
            // 
            // OutputTxt
            // 
            this.OutputTxt.Location = new System.Drawing.Point(166, 221);
            this.OutputTxt.Name = "OutputTxt";
            this.OutputTxt.Size = new System.Drawing.Size(466, 20);
            this.OutputTxt.TabIndex = 21;
            this.OutputTxt.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(7, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "Historic Climate Data:";
            // 
            // CruModel
            // 
            this.CruModel.AutoSize = true;
            this.CruModel.Location = new System.Drawing.Point(157, 35);
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
            this.ScenarioChk.Location = new System.Drawing.Point(157, 94);
            this.ScenarioChk.MultiColumn = true;
            this.ScenarioChk.Name = "ScenarioChk";
            this.ScenarioChk.Size = new System.Drawing.Size(645, 15);
            this.ScenarioChk.TabIndex = 50;
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
            this.ModelChk.Location = new System.Drawing.Point(157, 64);
            this.ModelChk.MultiColumn = true;
            this.ModelChk.Name = "ModelChk";
            this.ModelChk.Size = new System.Drawing.Size(734, 15);
            this.ModelChk.TabIndex = 49;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.ManualPanel);
            this.groupBox1.Controls.Add(this.ManualRb);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 178);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   Manual  browsing of data";
            // 
            // ManualPanel
            // 
            this.ManualPanel.Controls.Add(this.ModelChk);
            this.ManualPanel.Controls.Add(this.label15);
            this.ManualPanel.Controls.Add(this.CruModel);
            this.ManualPanel.Controls.Add(this.ScenarioChk);
            this.ManualPanel.Controls.Add(this.Temperature);
            this.ManualPanel.Controls.Add(this.Precipitation);
            this.ManualPanel.Controls.Add(this.label18);
            this.ManualPanel.Controls.Add(this.label19);
            this.ManualPanel.Controls.Add(this.label20);
            this.ManualPanel.Controls.Add(this.PpuFileBtn);
            this.ManualPanel.Controls.Add(this.label21);
            this.ManualPanel.Controls.Add(this.ManualFilesTxt);
            this.ManualPanel.Location = new System.Drawing.Point(5, 16);
            this.ManualPanel.Name = "ManualPanel";
            this.ManualPanel.Size = new System.Drawing.Size(821, 162);
            this.ManualPanel.TabIndex = 55;
            // 
            // Temperature
            // 
            this.Temperature.AutoSize = true;
            this.Temperature.Location = new System.Drawing.Point(278, 123);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(86, 17);
            this.Temperature.TabIndex = 19;
            this.Temperature.Text = "Temperature";
            this.Temperature.UseVisualStyleBackColor = true;
            // 
            // Precipitation
            // 
            this.Precipitation.AutoSize = true;
            this.Precipitation.Location = new System.Drawing.Point(158, 123);
            this.Precipitation.Name = "Precipitation";
            this.Precipitation.Size = new System.Drawing.Size(84, 17);
            this.Precipitation.TabIndex = 18;
            this.Precipitation.Text = "Precipitation";
            this.Precipitation.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label18.Location = new System.Drawing.Point(7, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Climate Variables:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label19.Location = new System.Drawing.Point(7, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 13);
            this.label19.TabIndex = 12;
            this.label19.Text = "Carbon Emission Scenarios:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label20.Location = new System.Drawing.Point(7, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Future  Climate Models:";
            // 
            // PpuFileBtn
            // 
            this.PpuFileBtn.Location = new System.Drawing.Point(649, 1);
            this.PpuFileBtn.Name = "PpuFileBtn";
            this.PpuFileBtn.Size = new System.Drawing.Size(53, 24);
            this.PpuFileBtn.TabIndex = 5;
            this.PpuFileBtn.Text = "browse";
            this.PpuFileBtn.UseVisualStyleBackColor = true;
            this.PpuFileBtn.Click += new System.EventHandler(this.PpuFileBtn_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label21.Location = new System.Drawing.Point(7, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "Input Data :";
            // 
            // ManualFilesTxt
            // 
            this.ManualFilesTxt.Location = new System.Drawing.Point(157, 4);
            this.ManualFilesTxt.Name = "ManualFilesTxt";
            this.ManualFilesTxt.Size = new System.Drawing.Size(463, 20);
            this.ManualFilesTxt.TabIndex = 3;
            // 
            // ManualRb
            // 
            this.ManualRb.AutoSize = true;
            this.ManualRb.Checked = true;
            this.ManualRb.Location = new System.Drawing.Point(3, 0);
            this.ManualRb.Name = "ManualRb";
            this.ManualRb.Size = new System.Drawing.Size(14, 13);
            this.ManualRb.TabIndex = 49;
            this.ManualRb.TabStop = true;
            this.ManualRb.UseVisualStyleBackColor = true;
            this.ManualRb.Visible = false;
            this.ManualRb.CheckedChanged += new System.EventHandler(this.ManualRb_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox2.Controls.Add(this.DirectRb);
            this.groupBox2.Controls.Add(this.DirectPanel);
            this.groupBox2.Location = new System.Drawing.Point(7, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(833, 15);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "   Direct  browsing of data";
            this.groupBox2.Visible = false;
            // 
            // DirectRb
            // 
            this.DirectRb.AutoSize = true;
            this.DirectRb.Location = new System.Drawing.Point(3, 0);
            this.DirectRb.Name = "DirectRb";
            this.DirectRb.Size = new System.Drawing.Size(14, 13);
            this.DirectRb.TabIndex = 16;
            this.DirectRb.UseVisualStyleBackColor = true;
            this.DirectRb.CheckedChanged += new System.EventHandler(this.DirectRb_CheckedChanged);
            // 
            // DirectPanel
            // 
            this.DirectPanel.Controls.Add(this.FilesBtn);
            this.DirectPanel.Controls.Add(this.label3);
            this.DirectPanel.Controls.Add(this.DirectFilesTxt);
            this.DirectPanel.Location = new System.Drawing.Point(6, 18);
            this.DirectPanel.Name = "DirectPanel";
            this.DirectPanel.Size = new System.Drawing.Size(741, 41);
            this.DirectPanel.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PlusRb);
            this.panel2.Controls.Add(this.RatioRb);
            this.panel2.Location = new System.Drawing.Point(166, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 31);
            this.panel2.TabIndex = 48;
            // 
            // OutputGcd
            // 
            this.OutputGcd.Location = new System.Drawing.Point(773, 254);
            this.OutputGcd.Name = "OutputGcd";
            this.OutputGcd.Size = new System.Drawing.Size(67, 48);
            this.OutputGcd.TabIndex = 49;
            this.OutputGcd.Text = "Browse Output";
            this.OutputGcd.UseVisualStyleBackColor = true;
            this.OutputGcd.Click += new System.EventHandler(this.OutputGcd_Click);
            // 
            // CorrectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 344);
            this.Controls.Add(this.OutputGcd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OutFilesBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OutputTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CruChk);
            this.Controls.Add(this.commentLbl);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.MeasuredBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MeasuredTxt);
            this.Controls.Add(this.AnomalyBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnomalyTxt);
            this.MaximizeBox = false;
            this.Name = "CorrectionForm";
            this.Text = "Bias Correction Statistical Downscaling (BCSD)";
            this.Load += new System.EventHandler(this.CorrectionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ManualPanel.ResumeLayout(false);
            this.ManualPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.DirectPanel.ResumeLayout(false);
            this.DirectPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AnomalyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AnomalyTxt;
        private System.Windows.Forms.Button MeasuredBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MeasuredTxt;
        private System.Windows.Forms.Button FilesBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DirectFilesTxt;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Label commentLbl;
        private System.Windows.Forms.RadioButton RatioRb;
        private System.Windows.Forms.RadioButton PlusRb;
        private System.Windows.Forms.CheckBox CruChk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button OutFilesBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OutputTxt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox CruModel;
        private System.Windows.Forms.CheckedListBox ScenarioChk;
        private System.Windows.Forms.CheckedListBox ModelChk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Temperature;
        private System.Windows.Forms.CheckBox Precipitation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button PpuFileBtn;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox ManualFilesTxt;
        private System.Windows.Forms.Panel ManualPanel;
        private System.Windows.Forms.RadioButton ManualRb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton DirectRb;
        private System.Windows.Forms.Panel DirectPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button OutputGcd;
    }
}

