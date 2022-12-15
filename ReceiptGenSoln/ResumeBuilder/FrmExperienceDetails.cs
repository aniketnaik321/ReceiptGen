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
    public partial class FrmExperienceDetails : Form
    {
        public FrmDataEntry DataEntryForm { get; set; }
        public CompanyExperience experienceData { get; set; }
        public int EditIndex { get; set; } = -1;
        public FrmExperienceDetails()
        {
            InitializeComponent();
            experienceData = new CompanyExperience();   
        }

        public void SetupEditData()
        {
            if (EditIndex >= 0)
            {
              txtCompanyName.Text = experienceData.CompanyName;
                txtDesignation.Text = experienceData.Designation;                
                dtpStartDate.Value = experienceData.FromDate;
                dtpEndDate.Value = experienceData.ToDate;
                }
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            experienceData.CompanyName =txtCompanyName.Text;
            experienceData.FromDate = dtpStartDate.Value;
            experienceData.ToDate = dtpEndDate.Value;
            experienceData.CurrentlyWorking = chkCurrentlyWorking.Checked;
            experienceData.Designation = txtDesignation.Text;
            DataEntryForm.ResumeDataWrapper.CompanyExperience.Add(experienceData);
            if (EditIndex >= 0)
            {
                this.DataEntryForm.ResumeDataWrapper.CompanyExperience[EditIndex] = experienceData;
            }
            else
            {
                DataEntryForm.ResumeDataWrapper.CompanyExperience.Add(experienceData);
            }

            DataEntryForm.RefreshCompanyExperienceDataGrid();
            this.Close();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmExperienceDetails_Paint(object sender, PaintEventArgs e)
        {
            txtCompanyName.Focus();
        }
    }
}
