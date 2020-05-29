using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCT;

namespace AllInOne
{
    public partial class AllInOneForm : Form
    {
        private int childFormNumber = 0;
        public string[] ModelsTip = new string[] { "GFDL-ESM2M", "HadGEM2-ES", "IPSL-CM45A-LR", "M1ROC", "Noer-ESM1-M", "", "" };
        public string[] SensTip = new string[] { "RCP2.6", "RCP4.5", "RCP6.0", "RCP8.5", "", "", "" };

        public AllInOneForm()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

   

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void CCDABtn_Click(object sender, EventArgs e)
        {
            CCDAWinApp.CCDA childForm = new CCDAWinApp.CCDA();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void GCDBtn_Click(object sender, EventArgs e)
        {
            GCD.GCD childForm = new GCD.GCD();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void FileCreatorBtn_Click(object sender, EventArgs e)
        {
            FileCreator.FileCreator childForm = new FileCreator.FileCreator();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void CorrectionBtn_Click(object sender, EventArgs e)
        {
            Correction.CorrectionForm childForm = new Correction.CorrectionForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void MainBtn_Click(object sender, EventArgs e)
        {
            CCT.CctMain childForm = new CCT.CctMain();
            childForm.MdiParent = this;
            childForm.Show();
        }

        public void BusyState()
        {
            busyLabel.Text = "Busy";
            busyLabel.ForeColor = Color.Red;
            busyLabel.Refresh();
        }
        public void ReadyState(){
           busyLabel.Text = "Ready";
           busyLabel.ForeColor = Color.Green;
            busyLabel.Refresh();
        }
        private void AllInOneForm_Load(object sender, EventArgs e)
        {
            var x=(this.Width/2)-250;
            var y = (this.Height / 2) - 230;
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = Color.White;
                    //client.BackgroundImage = CCT.Properties.Resources.cct_background;
                    // client.BackgroundImageLayout=ImageLayout.Center;

                     client.Paint += (s, e1) =>
                     {
                         using (Image bg = CCT.Properties.Resources.cct_background)
                         {
                             e1.Graphics.DrawImage(bg, new Rectangle(x, 50, 500, 460));
                         }
                     };
                    // 4#
                    break;
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var  curentDir = System.IO.Directory.GetCurrentDirectory();
          System.Diagnostics.Process.Start(curentDir +"/cct.pdf");
        }

        private void CMAABtn_Click(object sender, EventArgs e)
        {
            CMAA.CMAA childForm = new CMAA.CMAA();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void calculateAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }


        private void calculateAnomaliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GCDAll.GCDAll childForm = new GCDAll.GCDAll();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void calculateAverageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CMAA.CMAA childForm = new CMAA.CMAA();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
