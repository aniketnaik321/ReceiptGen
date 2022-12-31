using ResumeBuilder.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class FrmLoadingScreen : Form
    {


        private ApplicationDataService applicationDataService;
        public FrmLoadingScreen()
        {
            InitializeComponent();
            applicationDataService = new ApplicationDataService();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            timer1.Enabled = false;
            //Code to copy database file in user directory.
            applicationDataService.CopyDBFileToAppData();
            FrmMain frm = new FrmMain();
            frm.Show();
            this.Hide(); 
        }

        private void FrmLoadingScreen_Load(object sender, EventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, this.Height), // Vertical gradient.
                Color.YellowGreen,
                Color.AliceBlue); // Red to blue gradient.

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(gradientBrush, this.ClientRectangle);
            }
            this.BackgroundImage = bmp;

        }
    }
}
