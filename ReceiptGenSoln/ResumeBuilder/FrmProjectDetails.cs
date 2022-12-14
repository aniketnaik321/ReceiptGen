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
        public ProjectDetails projectDetails { get; set; }
        public int EditIndex{ get; set; }=-1;        
        public FrmProjectDetails()
        {
            InitializeComponent();
            projectDetails = new ProjectDetails();            
         }

        public void SetupEditData() {
            if (EditIndex >= 0)
            {
                txtProjectTitle.Text = projectDetails.ProjectName;
                txtClient.Text = projectDetails.ClientName;
                txtDescription.Text = projectDetails.RoleInProject;
                dtpEndDate.Value = projectDetails.ToDate;
                dtpStartDate.Value = projectDetails.FromDate;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            projectDetails.ProjectName = txtProjectTitle.Text;
            projectDetails.ClientName = txtClient.Text;
            projectDetails.FromDate = dtpStartDate.Value;
            projectDetails.ToDate = dtpEndDate.Value;
            projectDetails.Description = txtDescription.Text;
            projectDetails.RoleInProject = txtRoleInProject.Text;
            if (EditIndex >= 0)
            {
                this.DataEntryForm.ResumeDataWrapper.ProjectDetails[EditIndex]= projectDetails;
            }
            else {               
                this.DataEntryForm.ResumeDataWrapper.ProjectDetails.Add(projectDetails);
            }            
            this.DataEntryForm.RefreshProjectDetailsDataGrid();
            this.Close();
           // this.Dispose();
        }

        private void FrmProjectDetails_Paint(object sender, PaintEventArgs e)
        {
            txtClient.Focus();
        }
    }
}
