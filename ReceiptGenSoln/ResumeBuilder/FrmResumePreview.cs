using ResumeBuilder.DTO;
using ResumeBuilder.Infrastructure;
using ResumeBuilder.Service;
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
       DocumentService _documentService;
        ResumeDataService _resumeDataService;
        ResumeDataWrapper _resumeDataWrapper;
      
        public FrmResumePreview()
        {
            InitializeComponent();
            _viewer = new PdfDocumentViewer();
            _documentService = new DocumentService();
            _resumeDataService = new ResumeDataService();
        }

        private void FrmResumePreview_Load(object sender, EventArgs e)
        {
            _viewer.Dock = DockStyle.Fill;
            _viewer.Visible = true;
            _viewer.BringToFront();
            this.PreviewPanel.Controls.Add(_viewer);

            _resumeDataWrapper = _resumeDataService.LoadResumeData();
           
            _viewer.LoadFromFile(_documentService.FillupTemplate(Environment.CurrentDirectory + "//ResumeTemplates//template_1.docx", 1, _resumeDataWrapper));
            
        }
    }
}
