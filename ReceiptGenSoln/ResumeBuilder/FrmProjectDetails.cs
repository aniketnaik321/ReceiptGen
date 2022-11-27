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
    public partial class FrmProjectDetails : Form
    {

        public FrmDataEntry DataEntryForm { get; set; }
        private ProjectDetails _projectDetails;
        public FrmProjectDetails()
        {
            InitializeComponent();
            _projectDetails = new ProjectDetails();  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _projectDetails.ProjectName = txtProjectTitle.Text;
            _projectDetails.ClientName = txtClient.Text;
            _projectDetails.FromDate = dtpStartDate.Value.ToString("dd/MM/yyyy");
            _projectDetails.ToDate = dtpEndDate.Value.ToString("dd/MM/yyyy");
            _projectDetails.RoleInProject = txtDescription.Text;
            this.DataEntryForm.ResumeDataWrapper.ProjectDetails.Add(_projectDetails);
            this.DataEntryForm.RefreshProjectDetailsDataGrid();
            this.Close();
           // this.Dispose();
        }
    }
}
