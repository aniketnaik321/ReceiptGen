using ResumeBuilder.DTO;
using ResumeBuilder.Infrastructure;
using ResumeBuilder.Service;
using Spire.PdfViewer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace ResumeBuilder
{
    public partial class FrmResumePreview : Form
    {
        PdfDocumentViewer _viewer;
        DocumentService _documentService;
        ResumeDataService _resumeDataService;
        ResumeDataWrapper _resumeDataWrapper;
        private string TemplateFileName;
        DocX document;
      
        public FrmResumePreview(string templateFileName)
        {
            InitializeComponent();
            _viewer = new PdfDocumentViewer();
            _documentService = new DocumentService();
            _resumeDataService = new ResumeDataService();
            TemplateFileName = templateFileName;
        }

        private void FrmResumePreview_Load(object sender, EventArgs e)
        {
            _viewer.Dock = DockStyle.Fill;
            _viewer.Visible = true;
            _viewer.BringToFront();
            this.PreviewPanel.Controls.Add(_viewer);
            _resumeDataWrapper = _resumeDataService.LoadResumeData();
            MemoryStream tempDoc;
            using (MemoryStream ms = _documentService.FillupTemplate(
                Environment.CurrentDirectory + "//ResumeTemplates//" + TemplateFileName, 
                1, 
                _resumeDataWrapper,
                out tempDoc))
            {
                _viewer.LoadFromStream(ms);
                document=DocX.Load(tempDoc);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog()==DialogResult.OK)
                    _viewer.SaveToFile(saveFileDialog.FileName);
        }

        private void btnExportDocx_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)                
                document.SaveAs(saveFileDialog.FileName);
        }
    }
}
