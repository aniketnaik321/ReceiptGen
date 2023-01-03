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
                // pictureBox.PreviewThumbnail=Image.FromStream()
                //  pictureBox.TemplateName=
                //pictureBox.Dock=DockStyle.Fill;
                //   pictureBox.BackColor = Color.FromArgb(15, 59, 95);
                pictureBox.BackColor = Color.FromArgb(249,246,238);
                templatePanel.Controls.Add(pictureBox);
            }
        }

        private void PictureBox_ButtonClick(object sender, EventArgs e)
        {
             MessageBox.Show(((DtoResumeTemplate)sender).TemplateName);

            FrmResumePreview _frm = new FrmResumePreview(((DtoResumeTemplate)sender));           
            _frm.MdiParent = this.ParentForm;
            _frm.StartPosition = FormStartPosition.Manual;
         
            //_frm.WindowState = FormWindowState.Maximized;
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
