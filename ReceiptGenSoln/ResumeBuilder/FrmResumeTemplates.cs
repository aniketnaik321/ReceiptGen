using ResumeBuilder.DTO;
using ResumeBuilder.Service;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class FrmResumeTemplates : Form
    {

        private ResumeTemplateService _resumeTemplateService;
        public int CandidateID {get;set;}=1;
        public FrmResumeTemplates()
        {
            InitializeComponent();
            _resumeTemplateService = new ResumeTemplateService();
        }

        private void FrmResumeTemplates_Load(object sender, EventArgs e)
        {
            foreach (DtoResumeTemplate temp in _resumeTemplateService.GetTemplateList()) {
                CtrlPreviewBox pictureBox = new CtrlPreviewBox();
                pictureBox.Height = 450;
                pictureBox.Width = 400;
                pictureBox._resumeTemplate = temp;
                // Convert base 64 string to byte[]
                byte[] imageBytes = Convert.FromBase64String(temp.ThumbnailImage);
                // Convert byte[] to Image
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    pictureBox.PreviewThumbnail = Image.FromStream(ms, true);
                }
                pictureBox.SetButtonText(temp.TemplateName);
                pictureBox.ButtonClick += PictureBox_ButtonClick;
               
                pictureBox.BackColor = Color.FromArgb(249,246,238);
                templatePanel.Controls.Add(pictureBox);
            }
        }

        private void PictureBox_ButtonClick(object sender, EventArgs e)
        {
            FrmResumePreview _frm = new FrmResumePreview(((DtoResumeTemplate)sender),CandidateID);           
            _frm.MdiParent = this.ParentForm;
            _frm.StartPosition = FormStartPosition.Manual;
         
            _frm.Icon = this.Icon;
            _frm.Width = this.ParentForm.ClientSize.Width - 97;
            _frm.Height = this.ParentForm.ClientSize.Height - 30;
            _frm.Left = 0;
            _frm.Top = 0;
            _frm.Show();

            this.Close();
            this.Dispose();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
