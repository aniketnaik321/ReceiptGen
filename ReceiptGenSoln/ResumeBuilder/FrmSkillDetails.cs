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
    public partial class FrmSkillDetails : Form
    {

        public FrmDataEntry DataEntryForm { get; set; }
        public SkillDetails skillData { get; set; }

        public int EditIndex { get; set; } = -1;
        public FrmSkillDetails()
        {
            InitializeComponent();
            skillData = new SkillDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        public void SetupEditData()
        {
            if (EditIndex >= 0)
            {
                txtSkillName.Text = skillData.SkillName;
                ddlRating.SelectedIndex= ddlRating.Items.IndexOf(skillData.SkillRating);
               ddlRating.Text=skillData.SkillRating.ToString();
                txtSkillExperience.Text = skillData.SkillExperience;
            }
        }

        private void FrmSkillDetails_Load(object sender, EventArgs e)
        {
            ddlRating.SelectedIndex = 0;
        }

        private void FrmSkillDetails_Paint(object sender, PaintEventArgs e)
        {
            txtSkillName.Focus();
        }

        public void SetFocus() {
            txtSkillName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            skillData.SkillName = txtSkillName.Text;
            skillData.SkillRating =Convert.ToSingle(ddlRating.SelectedItem);
            skillData.SkillExperience = txtSkillExperience.Text;
            if (EditIndex >= 0)
            {
                this.DataEntryForm.ResumeDataWrapper.skillDetails[EditIndex] = skillData;
            }
            else
            {
                DataEntryForm.ResumeDataWrapper.skillDetails.Add(skillData);
            }
            DataEntryForm.RefreshSkillDetailsDataGrid();
            this.Close();
            this.Dispose();
        }
    }
}
