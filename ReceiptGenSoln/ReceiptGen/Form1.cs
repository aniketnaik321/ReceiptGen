using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiptGen
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
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.WhiteSmoke;
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReceipt frmReceipt = new FrmReceipt();
            frmReceipt.MdiParent = this;
            frmReceipt.StartPosition = FormStartPosition.CenterParent;
            frmReceipt.WindowState= FormWindowState.Maximized;
            frmReceipt.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            receiptToolStripMenuItem_Click(sender, e);
        }
    }
}
