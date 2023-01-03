using ResumeBuilder.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class FrmEducationDetails : Form
    {        
        public FrmDataEntry DataEntryForm { get; set; }
        public EducationData educationData { get; set; }

        public int EditIndex { get; set; } = -1;
        public FrmEducationDetails()
        {
            InitializeComponent();    
            educationData = new EducationData();
        }

        public void SetupEditData()
        {
            if (EditIndex >= 0)
            {
                txtCollege.Text = educationData.University;
                txtPercent.Text = educationData.PercentData;
                txtSpec.Text = educationData.Specification;

                dtpEndDate.Value = educationData.ToDate;
                dtpStartDate.Value = educationData.FromDate;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmEducationDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void FrmEducationDetails_Paint(object sender, PaintEventArgs e)
        {
            txtSpec.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {            
            educationData.University = txtCollege.Text;
            educationData.FromDate = dtpStartDate.Value;
            educationData.ToDate = dtpEndDate.Value;
            educationData.PercentData = txtPercent.Text;
            educationData.Specification = txtSpec.Text;

            if (EditIndex >= 0)
            {
                this.DataEntryForm.ResumeDataWrapper.EducationData[EditIndex] = educationData;
            }
            else
            {
                DataEntryForm.ResumeDataWrapper.EducationData.Add(educationData);
            }
            DataEntryForm.RefreshEducationDataGrid();
            this.Close();
            this.Dispose();
        }
    }
}
