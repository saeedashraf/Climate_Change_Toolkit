namespace AllInOne
{
    partial class AllInOneForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.MainBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.GCDBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CorrectionBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileCreatorBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CCDABtn = new System.Windows.Forms.ToolStripButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.busyLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsMenu,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1055, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(68, 19);
            this.windowsMenu.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.White;
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainBtn,
            this.toolStripSeparator4,
            this.GCDBtn,
            this.toolStripSeparator2,
            this.CorrectionBtn,
            this.toolStripSeparator1,
            this.FileCreatorBtn,
            this.toolStripSeparator3,
            this.CCDABtn});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1055, 87);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // MainBtn
            // 
            this.MainBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MainBtn.Image = global::CCT.Properties.Resources.data;
            this.MainBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MainBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MainBtn.Name = "MainBtn";
            this.MainBtn.Size = new System.Drawing.Size(84, 84);
            this.MainBtn.Text = "Main";
            this.MainBtn.Click += new System.EventHandler(this.MainBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 87);
            // 
            // GCDBtn
            // 
            this.GCDBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GCDBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GCDBtn.Image = global::CCT.Properties.Resources.GCDM;
            this.GCDBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GCDBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GCDBtn.Name = "GCDBtn";
            this.GCDBtn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.GCDBtn.Size = new System.Drawing.Size(84, 84);
            this.GCDBtn.Text = "GCDM";
            this.GCDBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.GCDBtn.Click += new System.EventHandler(this.GCDBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 87);
            // 
            // CorrectionBtn
            // 
            this.CorrectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CorrectionBtn.Image = global::CCT.Properties.Resources.BCSD;
            this.CorrectionBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CorrectionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CorrectionBtn.Name = "CorrectionBtn";
            this.CorrectionBtn.Size = new System.Drawing.Size(84, 84);
            this.CorrectionBtn.Text = "BCSD";
            this.CorrectionBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CorrectionBtn.Click += new System.EventHandler(this.CorrectionBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 87);
            // 
            // FileCreatorBtn
            // 
            this.FileCreatorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FileCreatorBtn.Image = global::CCT.Properties.Resources.sicd_2;
            this.FileCreatorBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FileCreatorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileCreatorBtn.Name = "FileCreatorBtn";
            this.FileCreatorBtn.Size = new System.Drawing.Size(84, 84);
            this.FileCreatorBtn.Text = "SICD";
            this.FileCreatorBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.FileCreatorBtn.Click += new System.EventHandler(this.FileCreatorBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 87);
            // 
            // CCDABtn
            // 
            this.CCDABtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CCDABtn.Image = global::CCT.Properties.Resources.CCDA;
            this.CCDABtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CCDABtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CCDABtn.Name = "CCDABtn";
            this.CCDABtn.Size = new System.Drawing.Size(84, 84);
            this.CCDABtn.Text = "CCDA";
            this.CCDABtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CCDABtn.Click += new System.EventHandler(this.CCDABtn_Click);
            // 
            // busyLabel
            // 
            this.busyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.busyLabel.AutoSize = true;
            this.busyLabel.ForeColor = System.Drawing.Color.Green;
            this.busyLabel.Location = new System.Drawing.Point(997, 85);
            this.busyLabel.Name = "busyLabel";
            this.busyLabel.Size = new System.Drawing.Size(50, 18);
            this.busyLabel.TabIndex = 3;
            this.busyLabel.Text = "Ready";
            // 
            // AllInOneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1055, 533);
            this.Controls.Add(this.busyLabel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "AllInOneForm";
            this.Text = "Climate Change Toolkit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AllInOneForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripButton CCDABtn;
        private System.Windows.Forms.ToolStripButton GCDBtn;
        private System.Windows.Forms.ToolStripButton FileCreatorBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton CorrectionBtn;
        private System.Windows.Forms.ToolStripButton MainBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.Label busyLabel;
    }
}



