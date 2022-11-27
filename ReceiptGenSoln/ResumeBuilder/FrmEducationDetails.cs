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
    public partial class FrmEducationDetails : Form
    {        
        public FrmDataEntry DataEntryForm { get; set; }
        private EducationData educationData;    
        public FrmEducationDetails()
        {
            InitializeComponent();    
            educationData = new EducationData();
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
            educationData.FromDate = dtpStartDate.Value.ToString("dd/MM/yyyy");
            educationData.ToDate= dtpEndDate.Value.ToString("dd/MM/yyyy");
            educationData.PercentData = txtPercent.Text;
            educationData.Specification = txtSpec.Text;
            DataEntryForm.ResumeDataWrapper.EducationData.Add(educationData);
            DataEntryForm.RefreshEducationDataGrid();
            this.Close();
            this.Dispose();
        }
    }
}
