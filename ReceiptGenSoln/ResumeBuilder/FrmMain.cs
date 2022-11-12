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
            Application.Exit();
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
            _frmDataEntry.MdiParent = this;
            _frmDataEntry.StartPosition = FormStartPosition.CenterScreen;
            _frmDataEntry.WindowState = FormWindowState.Maximized;
            _frmDataEntry.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            receiptToolStripMenuItem_Click(sender, e);
        }
    }
}
