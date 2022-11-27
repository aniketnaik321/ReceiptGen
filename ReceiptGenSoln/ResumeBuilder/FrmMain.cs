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
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.WhiteSmoke;
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            FrmDataEntry _frmDataEntry = new FrmDataEntry();
            if (!refreshChildForms(_frmDataEntry.Name)) { _frmDataEntry = null; return; }
            _frmDataEntry.MdiParent = this;
            _frmDataEntry.StartPosition = FormStartPosition.CenterScreen;
            _frmDataEntry.WindowState = FormWindowState.Maximized;
            _frmDataEntry.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            receiptToolStripMenuItem_Click(sender, e);
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

        private void templatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResumeTemplates _frm = new FrmResumeTemplates();
            if (!refreshChildForms(_frm.Name)) { _frm = null; return; }
            _frm.MdiParent = this;
            _frm.StartPosition = FormStartPosition.CenterScreen;
            _frm.WindowState = FormWindowState.Maximized;
            _frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            templatesToolStripMenuItem_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }
    }
}
