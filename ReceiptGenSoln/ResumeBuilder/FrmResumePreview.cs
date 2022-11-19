using Spire.PdfViewer.Forms;
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
    public partial class FrmResumePreview : Form
    {
        PdfDocumentViewer _viewer;
        public FrmResumePreview()
        {
            InitializeComponent();
            _viewer = new PdfDocumentViewer();
        }

        private void FrmResumePreview_Load(object sender, EventArgs e)
        {
            _viewer.Dock = DockStyle.Fill;
            _viewer.Visible = true;
            _viewer.BringToFront();
            this.PreviewPanel.Controls.Add(_viewer);
            _viewer.LoadFromFile(@"C:\Resume.pdf");
        }
    }
}
