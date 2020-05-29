namespace FileCreator
{
    partial class FileCreator
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
            this.RunBtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.CruModel = new System.Windows.Forms.CheckBox();
            this.LongTo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LongFrom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.LatTo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LatFrom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.stepTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.elevChk = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DirectRb = new System.Windows.Forms.RadioButton();
            this.DirectPanel = new System.Windows.Forms.Panel();
            this.FilesBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DirectFilesTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ManualPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ObservedUserDBChk = new System.Windows.Forms.CheckBox();
            this.ObserveModel = new System.Windows.Forms.CheckBox();
            this.ModelChk = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ScenarioChk = new System.Windows.Forms.CheckedListBox();
            this.Temperature = new System.Windows.Forms.CheckBox();
            this.Precipitation = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.ManualFilesTxt = new System.Windows.Forms.TextBox();
            this.ManualRb = new System.Windows.Forms.RadioButton();
            this.OutputGcd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            this.DirectPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ManualPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RunBtn
            // 
            this.RunBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.RunBtn.Location = new System.Drawing.Point(743, 253);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(93, 31);
            this.RunBtn.TabIndex = 0;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = false;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(685, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "Data set :";
            this.label15.Visible = false;
            // 
            // CruModel
            // 
            this.CruModel.AutoSize = true;
            this.CruModel.Location = new System.Drawing.Point(743, 224);
            this.CruModel.Name = "CruModel";
            this.CruModel.Size = new System.Drawing.Size(93, 17);
            this.CruModel.TabIndex = 53;
            this.CruModel.Text = "Historic (CRU)";
            this.CruModel.UseVisualStyleBackColor = true;
            this.CruModel.Visible = false;
            // 
            // LongTo
            // 
            this.LongTo.Location = new System.Drawing.Point(403, 306);
            this.LongTo.Name = "LongTo";
            this.LongTo.Size = new System.Drawing.Size(121, 20);
            this.LongTo.TabIndex = 64;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(374, 309);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "To:";
            // 
            // LongFrom
            // 
            this.LongFrom.Location = new System.Drawing.Point(174, 306);
            this.LongFrom.Name = "LongFrom";
            this.LongFrom.Size = new System.Drawing.Size(121, 20);
            this.LongFrom.TabIndex = 62;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(135, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "From:";
            // 
            // LatTo
            // 
            this.LatTo.Location = new System.Drawing.Point(403, 280);
            this.LatTo.Name = "LatTo";
            this.LatTo.Size = new System.Drawing.Size(121, 20);
            this.LatTo.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "To:";
            // 
            // LatFrom
            // 
            this.LatFrom.Location = new System.Drawing.Point(174, 280);
            this.LatFrom.Name = "LatFrom";
            this.LatFrom.Size = new System.Drawing.Size(121, 20);
            this.LatFrom.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "From:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(43, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "longitude:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(43, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Latitude:";
            // 
            // stepTxt
            // 
            this.stepTxt.Location = new System.Drawing.Point(174, 251);
            this.stepTxt.Name = "stepTxt";
            this.stepTxt.Size = new System.Drawing.Size(121, 20);
            this.stepTxt.TabIndex = 67;
            this.stepTxt.Text = "0.5";
            this.toolTip2.SetToolTip(this.stepTxt, "For the first time of Interpolation this variable should be 0.5 and for the secon" +
        "d time this should be 0.25.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(43, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Current Grid Size :";
            this.toolTip2.SetToolTip(this.label3, "For the first time of Interpolation this variable should be 0.5 and for the secon" +
        "d time this should be 0.25.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(43, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Method :";
            this.label2.Visible = false;
            // 
            // elevChk
            // 
            this.elevChk.AutoSize = true;
            this.elevChk.Location = new System.Drawing.Point(175, 222);
            this.elevChk.Name = "elevChk";
            this.elevChk.Size = new System.Drawing.Size(128, 17);
            this.elevChk.TabIndex = 68;
            this.elevChk.Text = "Considering Elevation";
            this.elevChk.UseVisualStyleBackColor = true;
            this.elevChk.Visible = false;
            this.elevChk.CheckedChanged += new System.EventHandler(this.elevChk_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox2.Controls.Add(this.DirectRb);
            this.groupBox2.Controls.Add(this.DirectPanel);
            this.groupBox2.Location = new System.Drawing.Point(12, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(833, 15);
            this.groupBox2.TabIndex = 71;
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
            this.DirectPanel.Controls.Add(this.label4);
            this.DirectPanel.Controls.Add(this.DirectFilesTxt);
            this.DirectPanel.Location = new System.Drawing.Point(6, 18);
            this.DirectPanel.Name = "DirectPanel";
            this.DirectPanel.Size = new System.Drawing.Size(741, 41);
            this.DirectPanel.TabIndex = 15;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Files Folder :";
            // 
            // DirectFilesTxt
            // 
            this.DirectFilesTxt.Location = new System.Drawing.Point(153, 11);
            this.DirectFilesTxt.Name = "DirectFilesTxt";
            this.DirectFilesTxt.Size = new System.Drawing.Size(466, 20);
            this.DirectFilesTxt.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.ManualPanel);
            this.groupBox1.Controls.Add(this.ManualRb);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 178);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   Selection of Climate Models, RCP scenarios, and Climate variables, which shoul" +
    "d be interpolated";
            // 
            // ManualPanel
            // 
            this.ManualPanel.Controls.Add(this.label14);
            this.ManualPanel.Controls.Add(this.label13);
            this.ManualPanel.Controls.Add(this.ObservedUserDBChk);
            this.ManualPanel.Controls.Add(this.ObserveModel);
            this.ManualPanel.Controls.Add(this.ModelChk);
            this.ManualPanel.Controls.Add(this.label5);
            this.ManualPanel.Controls.Add(this.checkBox1);
            this.ManualPanel.Controls.Add(this.ScenarioChk);
            this.ManualPanel.Controls.Add(this.Temperature);
            this.ManualPanel.Controls.Add(this.Precipitation);
            this.ManualPanel.Controls.Add(this.label18);
            this.ManualPanel.Controls.Add(this.label20);
            this.ManualPanel.Controls.Add(this.button1);
            this.ManualPanel.Controls.Add(this.label21);
            this.ManualPanel.Controls.Add(this.ManualFilesTxt);
            this.ManualPanel.Location = new System.Drawing.Point(5, 16);
            this.ManualPanel.Name = "ManualPanel";
            this.ManualPanel.Size = new System.Drawing.Size(821, 162);
            this.ManualPanel.TabIndex = 55;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label14.Location = new System.Drawing.Point(7, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 29);
            this.label14.TabIndex = 65;
            this.label14.Text = "Representative Concentration Pathways (RCPs):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label13.Location = new System.Drawing.Point(7, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(185, 13);
            this.label13.TabIndex = 64;
            this.label13.Text = "Check if ObservedUser is being used.";
            // 
            // ObservedUserDBChk
            // 
            this.ObservedUserDBChk.AutoSize = true;
            this.ObservedUserDBChk.Location = new System.Drawing.Point(206, 142);
            this.ObservedUserDBChk.Name = "ObservedUserDBChk";
            this.ObservedUserDBChk.Size = new System.Drawing.Size(115, 17);
            this.ObservedUserDBChk.TabIndex = 63;
            this.ObservedUserDBChk.Text = "ObservedUser_DB";
            this.ObservedUserDBChk.UseVisualStyleBackColor = true;
            this.ObservedUserDBChk.CheckedChanged += new System.EventHandler(this.ObservedUserDBChk_CheckedChanged);
            // 
            // ObserveModel
            // 
            this.ObserveModel.AutoSize = true;
            this.ObserveModel.Location = new System.Drawing.Point(327, 35);
            this.ObserveModel.Name = "ObserveModel";
            this.ObserveModel.Size = new System.Drawing.Size(94, 17);
            this.ObserveModel.TabIndex = 62;
            this.ObserveModel.Text = "ObservedUser";
            this.ObserveModel.UseVisualStyleBackColor = true;
            this.ObserveModel.CheckedChanged += new System.EventHandler(this.ObserveModel_CheckedChanged);
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
            this.ModelChk.Location = new System.Drawing.Point(206, 64);
            this.ModelChk.MultiColumn = true;
            this.ModelChk.Name = "ModelChk";
            this.ModelChk.Size = new System.Drawing.Size(734, 15);
            this.ModelChk.TabIndex = 49;
            this.ModelChk.MouseHover += new System.EventHandler(this.ModelChk_MouseHover);
            this.ModelChk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ModelChk_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(7, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Observed Climate Data:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(206, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 17);
            this.checkBox1.TabIndex = 51;
            this.checkBox1.Text = "ObservedCru";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            this.ScenarioChk.Location = new System.Drawing.Point(206, 94);
            this.ScenarioChk.MultiColumn = true;
            this.ScenarioChk.Name = "ScenarioChk";
            this.ScenarioChk.Size = new System.Drawing.Size(645, 15);
            this.ScenarioChk.TabIndex = 50;
            this.ScenarioChk.MouseHover += new System.EventHandler(this.ScenarioChk_MouseHover);
            this.ScenarioChk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScenarioChk_MouseMove);
            // 
            // Temperature
            // 
            this.Temperature.AutoSize = true;
            this.Temperature.Location = new System.Drawing.Point(327, 120);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(86, 17);
            this.Temperature.TabIndex = 19;
            this.Temperature.Text = "Temperature";
            this.Temperature.UseVisualStyleBackColor = true;
            // 
            // Precipitation
            // 
            this.Precipitation.AutoSize = true;
            this.Precipitation.Location = new System.Drawing.Point(207, 120);
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
            this.label18.Location = new System.Drawing.Point(7, 120);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Climate Variables:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label20.Location = new System.Drawing.Point(7, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(152, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Global Climate Models (GCMs):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(649, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "browse";
            this.toolTip2.SetToolTip(this.button1, "Most of the time you do Bias Correction then Interpolation. Recomendation: Brows " +
        "Bias-Corrected folder.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.toolTip2.SetToolTip(this.ManualFilesTxt, "Most of the time you do Bias Correction then Interpolation. Recomendation: Brows " +
        "Bias-Corrected folder.");
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
            // OutputGcd
            // 
            this.OutputGcd.Location = new System.Drawing.Point(743, 288);
            this.OutputGcd.Name = "OutputGcd";
            this.OutputGcd.Size = new System.Drawing.Size(93, 38);
            this.OutputGcd.TabIndex = 72;
            this.OutputGcd.Text = "Browse Output";
            this.OutputGcd.UseVisualStyleBackColor = true;
            this.OutputGcd.Click += new System.EventHandler(this.OutputGcd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(310, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 38);
            this.panel1.TabIndex = 73;
            this.panel1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(179, 7);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(43, 20);
            this.textBox2.TabIndex = 64;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(136, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "PLaps";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 20);
            this.textBox1.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "TLaps";
            // 
            // FileCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 333);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OutputGcd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.elevChk);
            this.Controls.Add(this.stepTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LongTo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LongFrom);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LatTo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LatFrom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CruModel);
            this.Controls.Add(this.RunBtn);
            this.MaximizeBox = false;
            this.Name = "FileCreator";
            this.Text = "Spatial Interpolation of Climate Data (SICD)";
            this.Load += new System.EventHandler(this.FileCreator_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.DirectPanel.ResumeLayout(false);
            this.DirectPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ManualPanel.ResumeLayout(false);
            this.ManualPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox CruModel;
        private System.Windows.Forms.TextBox LongTo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox LongFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox LatTo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox LatFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox stepTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox elevChk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton DirectRb;
        private System.Windows.Forms.Panel DirectPanel;
        private System.Windows.Forms.Button FilesBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DirectFilesTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel ManualPanel;
        private System.Windows.Forms.CheckedListBox ModelChk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckedListBox ScenarioChk;
        private System.Windows.Forms.CheckBox Temperature;
        private System.Windows.Forms.CheckBox Precipitation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox ManualFilesTxt;
        private System.Windows.Forms.RadioButton ManualRb;
        private System.Windows.Forms.Button OutputGcd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ObserveModel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ObservedUserDBChk;
        private System.Windows.Forms.Label label14;
    }
}

