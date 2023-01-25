﻿using PdfiumViewer;
using ResumeBuilder.DTO;
using ResumeBuilder.Service;
using System;
using System.IO;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace ResumeBuilder
{
    public partial class FrmResumePreview : Form
    {       
        PdfiumViewer.PdfViewer _viewer;       
        DocumentService _documentService;
        ResumeDataService _resumeDataService;
        ResumeDataWrapper _resumeDataWrapper;
        private DtoResumeTemplate TemplateFile;
        private DocX document;
        public int CandidateID;
      
        public FrmResumePreview(DtoResumeTemplate template)
        {
            InitializeComponent();
            _viewer = new PdfViewer();
            _viewer.ShowToolbar = false;            
            _documentService = new DocumentService();
            _resumeDataService = new ResumeDataService();
            TemplateFile = template;
        }

        private void FrmResumePreview_Load(object sender, EventArgs e)
        {
            _viewer.Dock = DockStyle.Fill;
            _viewer.Visible = true;
            _viewer.BringToFront();
            this.PreviewPanel.Controls.Add(_viewer);
            _resumeDataWrapper = _resumeDataService.LoadResumeData(1);
            MemoryStream tempDoc;
            MemoryStream ms = _documentService.FillupTemplate(
                Environment.CurrentDirectory + "//ResumeTemplates//" + TemplateFile.FileName, 
                TemplateFile, 
                _resumeDataWrapper,
                out tempDoc);
                _viewer.Document?.Dispose();
                _viewer.Document = PdfDocument.Load(ms);
                _viewer.Renderer.Zoom = 1.5;
                document=DocX.Load(tempDoc);            
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "PDF File|*.pdf";
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
                    _viewer.Document.Save(saveFileDialog.FileName);
        }

        private void btnExportDocx_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "DocX File|*.docx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)                
                document.SaveAs(saveFileDialog.FileName);
        }

        private void FrmResumePreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            

         }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            FrmResumeTemplates _frm = new FrmResumeTemplates();            
            _frm.MdiParent = this.ParentForm;
            _frm.Icon = this.Icon;
            _frm.Width = this.ParentForm.ClientSize.Width - 97;
            _frm.Height = this.ParentForm.ClientSize.Height - 30;
            _frm.Left = 0;
            _frm.Top = 0;
            _frm.WindowState = FormWindowState.Normal;            
            _frm.StartPosition = FormStartPosition.Manual;
            _frm.Show();

            this.Close();
            try
            { this.Dispose(); }
            catch (Exception) { }

        
        }
    }
}
