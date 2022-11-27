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
        private SkillDetails skillDetails;
        public FrmSkillDetails()
        {
            InitializeComponent();   
            skillDetails = new SkillDetails();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
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
            skillDetails.SkillName = txtSkillName.Text;
            skillDetails.SkillRating =Convert.ToSingle(ddlRating.SelectedItem);
            skillDetails.SkillExperience = txtSkillExperience.Text;
            DataEntryForm.ResumeDataWrapper.skillDetails.Add(skillDetails);
            DataEntryForm.RefreshSkillDetailsDataGrid();
            this.Close();
            this.Dispose();
        }
    }
}
