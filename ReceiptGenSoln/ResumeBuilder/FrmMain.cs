using ResumeBuilder.DTO;
using ResumeBuilder.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirm sign out, all unsaved changes will be lost?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
            HighLightButton(sender as ToolStripButton);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(51, 102, 153);
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            FrmDataEntry _frmDataEntry = new FrmDataEntry();
            if (!refreshChildForms(_frmDataEntry.Name)) { _frmDataEntry = null; return; }
            _frmDataEntry.MdiParent = this;
            _frmDataEntry.Icon=this.Icon;
            _frmDataEntry.Width = this.ClientSize.Width - 97;
            _frmDataEntry.Height = this.ClientSize.Height - 30;
            _frmDataEntry.Left = 0;
            _frmDataEntry.Top = 0;
            //_frmDataEntry.SetBounds(0, 0, this.ClientSize.Width-100, this.ClientSize.Height-60);
            _frmDataEntry.StartPosition = FormStartPosition.Manual; 

           // _frmDataEntry.WindowState = FormWindowState.Maximized;
            _frmDataEntry.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            receiptToolStripMenuItem_Click(sender, e);
            HighLightButton(sender as ToolStripButton);
        }


        //Also makes sure that there is only one instance of that form.
        private bool refreshChildForms(string existingFormName)
        {
            bool result = true;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(existingFormName)) 
                    { result = false; continue; }
                Console.WriteLine(frm.Name);
                frm.Close();
            }
            return result;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            //FrmResumePreview _frm= new FrmResumePreview();
            //if (!refreshChildForms(_frm.Name)) { _frm = null; return; }
            //_frm.MdiParent = this;
            //_frm.StartPosition = FormStartPosition.CenterScreen;
            //_frm.WindowState = FormWindowState.Maximized;
            //_frm.Show();

          //  MessageBox.Show("@" + string.Join(",@", EtyService.GetColumnNames<DtoResumeData>()));           
           // MessageBox.Show("This is for test-" + string.Join(" | ",EtyService.GetColumnNames<DtoResumeData>()));            
        }

        public void templatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResumeTemplates _frm = new FrmResumeTemplates();
            if (!refreshChildForms(_frm.Name)) { _frm = null; return; }
            _frm.MdiParent = this;
           _frm.Width = this.ClientSize.Width - 97;
           _frm.Height = this.ClientSize.Height - 30;
           _frm.Left = 0;
            _frm.Top = 0;
            //_frmDataEntry.SetBounds(0, 0, this.ClientSize.Width-100, this.ClientSize.Height-60);
            _frm.StartPosition = FormStartPosition.Manual;
            _frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            templatesToolStripMenuItem_Click(sender, e);
            HighLightButton(sender as ToolStripButton);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }


        private void HighLightButton(ToolStripButton btn) {
            foreach (ToolStripItem control in this.toolStrip1.Items) {
                if (control is ToolStripButton) {
                    control.BackColor = Color.FromArgb(15, 59, 95);
                  //  control.ForeColor = Color.Black;
                }            
            }

            btn.BackColor = Color.CornflowerBlue;
            btn.ForeColor= Color.AntiqueWhite;
        }

        public void btnCandidates_Click(object sender, EventArgs e)
        {
            HighLightButton(sender as ToolStripButton);
            FrmAllCandidates _frm = new FrmAllCandidates();
            if (!refreshChildForms(_frm.Name)) { _frm = null; return; }
            _frm.MdiParent = this;
            _frm.Icon= this.Icon;
            _frm.Width = this.ClientSize.Width - 97;
            _frm.Height = this.ClientSize.Height - 30;
            _frm.Left = 0;
            _frm.Top = 0;
            //_frmDataEntry.SetBounds(0, 0, this.ClientSize.Width-100, this.ClientSize.Height-60);
            _frm.StartPosition = FormStartPosition.Manual;
            _frm.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }
    }
}
