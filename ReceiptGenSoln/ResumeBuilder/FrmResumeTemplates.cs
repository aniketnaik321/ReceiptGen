using ResumeBuilder.DTO;
using ResumeBuilder.Service;
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

namespace ResumeBuilder
{
    public partial class FrmResumeTemplates : Form
    {

        private ResumeTemplateService _resumeTemplateService;
        public FrmResumeTemplates()
        {
            InitializeComponent();
            _resumeTemplateService = new ResumeTemplateService();
        }

        private void FrmResumeTemplates_Load(object sender, EventArgs e)
        {
            foreach (DtoResumeTemplates temp in _resumeTemplateService.GetTemplateList()) {
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

                pictureBox.ButtonClick += PictureBox_ButtonClick;

               // pictureBox.PreviewThumbnail=Image.FromStream()
                //  pictureBox.TemplateName=
                //pictureBox.Dock=DockStyle.Fill;
                pictureBox.BackColor = Color.Green;
                templatePanel.Controls.Add(pictureBox);
            }
        }

        private void PictureBox_ButtonClick(object sender, EventArgs e)
        {
             MessageBox.Show(((DtoResumeTemplates)sender).TemplateName);

            FrmResumePreview _frm = new FrmResumePreview(((DtoResumeTemplates)sender).FileName);           
            _frm.MdiParent = this.ParentForm;
            _frm.StartPosition = FormStartPosition.CenterScreen;
            _frm.WindowState = FormWindowState.Maximized;
            _frm.Show();
        }
    }
}
