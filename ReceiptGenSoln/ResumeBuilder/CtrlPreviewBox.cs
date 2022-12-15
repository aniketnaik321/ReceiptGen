using ResumeBuilder.DTO;
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
    public partial class CtrlPreviewBox : UserControl
    {
        public DtoResumeTemplate _resumeTemplate { get; set; }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler ButtonClick;
        public Image PreviewThumbnail {
            get { 
            return PreviewThumbnail;
            } set {
                this.pictureBox1.BackgroundImage = value;

            } 
        }

        public CtrlPreviewBox()
        {
            InitializeComponent();           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
                this.ButtonClick(_resumeTemplate, e);
        }
    }
}
