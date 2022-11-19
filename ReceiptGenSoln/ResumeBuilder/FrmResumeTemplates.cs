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
    public partial class FrmResumeTemplates : Form
    {
        public FrmResumeTemplates()
        {
            InitializeComponent();
        }

        private void FrmResumeTemplates_Load(object sender, EventArgs e)
        {
            
            for (int itr = 0; itr < 10; itr++) {
                CtrlPreviewBox pictureBox = new CtrlPreviewBox();
                pictureBox.Height = 450;
                pictureBox.Width = 400;
                //pictureBox.Dock=DockStyle.Fill;
                pictureBox.BackColor= Color.Green;
                templatePanel.Controls.Add(pictureBox);
            }
        }
    }
}
