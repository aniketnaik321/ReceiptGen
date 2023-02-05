using ResumeBuilder.DTO;
using ResumeBuilder.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class FrmDataEntry : Form
    {
        private ResumeDataService _resumeDataService;
        public DtoResumeData ResumeData;
        private string CandidatePhoto;
        public bool IsNew { get; set; } = false;
        public ResumeDataWrapper ResumeDataWrapper { get; set; }

        public FrmDataEntry()
        {
            InitializeComponent();     
            _resumeDataService = new ResumeDataService();
            ResumeDataWrapper = new ResumeDataWrapper();
            ResumeDataWrapper.CompanyExperience = new List<CompanyExperience>();
            ResumeDataWrapper.EducationData = new List<EducationData>();
            ResumeDataWrapper.skillDetails = new List<SkillDetails>();
            ResumeDataWrapper.ProjectDetails = new List<ProjectDetails>();
        }

        private void FrmDataEntry_Load(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                LoadCandidateData(1);
            }          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }    

        private void btnAddEducation_Click(object sender, EventArgs e)
        {
            if (dgvEducationalData.Rows.Count > 6) {
                MessageBox.Show("Education details is restricted to 7 entries only","Resume Builder",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            FrmEducationDetails frm = new FrmEducationDetails();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.DataEntryForm = this;
            frm.ShowDialog();

            DataGridViewRow _rw = new DataGridViewRow();         
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex) {
                case 0:
                    break;
                case 1:
                    //if (dgvEducationalData.Rows.Count == 0)
                    //{
                    //    DataGridViewRow _rw = new DataGridViewRow();
                    //    _rw.Tag = Guid.NewGuid().ToString();
                    //    dgvEducationalData.Rows.Add(_rw);
                    //}
                    break;
                case 2:
                    //if (dgvExperienceDetails.Rows.Count == 0)
                      //  btnAddExperienceDetails_Click(sender, e);                    
                    break;

                case 3:
                   // if (dgvSkillData.Rows.Count == 0)
                       // btnAddSkill_Click(sender, e);
                    break;                   
            }
        }

        private void dgvEducationalData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (e.ColumnIndex) {

                case 6:
                    FrmProjectDetails frm = new FrmProjectDetails();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.DataEntryForm = this;
                    frm.EditIndex = e.RowIndex;
                    frm.projectDetails = this.ResumeDataWrapper.ProjectDetails[e.RowIndex];
                    frm.SetupEditData();
                    frm.ShowDialog();

                    break;
                case 7:

                    if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       
                        ResumeDataWrapper.EducationData.RemoveAt(e.RowIndex);
                        dgvEducationalData.Rows.RemoveAt(e.RowIndex);
                    }
                    break;
            }
        }

        private void btnAddExperienceDetails_Click(object sender, EventArgs e)
        {            
            FrmExperienceDetails frm = new FrmExperienceDetails();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.DataEntryForm = this;
            frm.ShowDialog();

        }

        private void dgvExperienceDetails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGridViewRow row = dgvExperienceDetails.Rows[e.RowIndex];            
            //if (e.RowIndex != -1)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //        if (cell.ColumnIndex == 1|| cell.ColumnIndex == 2)
            //        {
            //            var dateTimePicker = new DateTimePicker();
            //            dateTimePicker.Font = new Font("Segoe UI", 9);
            //            dateTimePicker.Name = "dtp" + row.Tag + "-" + cell.ColumnIndex.ToString();
            //            dgvExperienceDetails.Controls.Add(dateTimePicker);
            //            dateTimePicker.Format = DateTimePickerFormat.Short;
            //            Rectangle oRectangle = dgvExperienceDetails.GetCellDisplayRectangle(cell.ColumnIndex, e.RowIndex, true);
            //            dateTimePicker.Size = new Size(oRectangle.Width - 2, oRectangle.Height - 10);
            //            dateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);
            //        }
            //}
        }

        private void dgvExperienceDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5:
                    FrmExperienceDetails frm = new FrmExperienceDetails();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.DataEntryForm = this;
                    frm.EditIndex = e.RowIndex;
                    frm.experienceData = this.ResumeDataWrapper.CompanyExperience[e.RowIndex];
                    frm.SetupEditData();
                    frm.ShowDialog();
                    break;
                case 6:

                    if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvProjectDetails.Rows.RemoveAt(e.RowIndex);
                        ResumeDataWrapper.CompanyExperience.RemoveAt(e.RowIndex);
                        RefreshCompanyExperienceDataGrid();
                    }
                    break;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ResumeData = new DtoResumeData();
            ResumeData.ContactNo = txtContactNo.Text;
            ResumeData.EmailID = txtEmail.Text;
            ResumeData.Address = txtAddress.Text;
            ResumeData.CandidateName = txtName.Text;
            ResumeData.Hobbies = txtHobbies.Text;
            ResumeData.DeclarationText = txtDeclarationText.Text;
            ResumeData.Portfolio = txtPortfolio.Text;
            ResumeData.ResumeTitle = txtResumeTitle.Text;
            ResumeData.ResumeSummary = txtResumeSummary.Text;
            ResumeData.CandidatePhoto = CandidatePhoto;
            if (ResumeDataWrapper.resumeData != null)
            {
                ResumeData.Id = ResumeDataWrapper.resumeData.Id;
            }
            ResumeDataWrapper.resumeData=ResumeData;
            if(_resumeDataService.UpdateResumeData(ResumeDataWrapper)>0)
                MessageBox.Show("Update successfull!","Resume Builder",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            if (dgvSkillData.Rows.Count > 6)
            {
                MessageBox.Show("Skill details is restricted to 7 entries only", "Easy Resume Builder",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FrmSkillDetails frm = new FrmSkillDetails();
           
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.DataEntryForm = this;
            frm.ShowDialog();
        }

        private void dgvSkillData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3:
                    FrmSkillDetails frm = new FrmSkillDetails();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.DataEntryForm = this;
                    frm.EditIndex = e.RowIndex;
                    frm.skillData = this.ResumeDataWrapper.skillDetails[e.RowIndex];
                    frm.SetupEditData();
                    frm.ShowDialog();
                    break;
                case 4:

                    if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvProjectDetails.Rows.RemoveAt(e.RowIndex);
                        ResumeDataWrapper.skillDetails.RemoveAt(e.RowIndex);
                        RefreshSkillDetailsDataGrid();
                    }
                    break;
            }
        }

        private void btnProjectDetails_Click(object sender, EventArgs e)
        {
            FrmProjectDetails frm = new FrmProjectDetails();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.DataEntryForm = this;
            frm.ShowDialog();
        }

        public void LoadCandidateData(int CandidateID) {
            ResumeDataWrapper= _resumeDataService.LoadResumeData(CandidateID);            
            if (ResumeDataWrapper != null && ResumeDataWrapper.resumeData!=null) {
                txtName.Text = ResumeDataWrapper.resumeData.CandidateName??String.Empty;
                txtAddress.Text = ResumeDataWrapper.resumeData.Address ?? String.Empty;
                txtContactNo.Text = ResumeDataWrapper.resumeData.ContactNo ?? String.Empty;
                txtDeclarationText.Text = ResumeDataWrapper.resumeData.DeclarationText ?? String.Empty;
                txtHobbies.Text = ResumeDataWrapper.resumeData.Hobbies ?? String.Empty;
                txtPortfolio.Text = ResumeDataWrapper.resumeData.Portfolio ?? String.Empty;
                txtEmail.Text= ResumeDataWrapper.resumeData.EmailID ?? String.Empty;
                txtResumeTitle.Text = ResumeDataWrapper.resumeData.ResumeTitle?? String.Empty;
                txtResumeSummary.Text = ResumeDataWrapper.resumeData.ResumeSummary ?? String.Empty;

                if (!string.IsNullOrWhiteSpace(ResumeDataWrapper.resumeData.CandidatePhoto))
                {
                    byte[] imageBytes = Convert.FromBase64String(ResumeDataWrapper.resumeData.CandidatePhoto);
                    // Convert byte[] to Image
                    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                    {
                        picCandidatePhoto.BackgroundImage = Image.FromStream(ms, true);
                    }
                }
            }
            RefreshEducationDataGrid();
            RefreshCompanyExperienceDataGrid();
            RefreshSkillDetailsDataGrid();
            RefreshProjectDetailsDataGrid();
        }

        public void RefreshEducationDataGrid() {
            this.dgvEducationalData.Rows.Clear();
            foreach (var tempEdudata in this.ResumeDataWrapper.EducationData) {
                this.dgvEducationalData.Rows.Add(tempEdudata.GetType()
                        .GetProperties()
                        .Select(p =>
                        {
                            object value = p.GetValue(tempEdudata, null);
                            if (p.PropertyType.ToString() == "System.DateTime")
                            {
                                return value == null ? string.Empty : UtilityService.DateFormatInDateMonthAndYear(value.ToString());
                            }
                            return value == null ? string.Empty : value.ToString();
                        })
                        .ToArray());
            
            }
          //  this.dgvEducationalData.DataSource=this.ResumeDataWrapper.EducationData;
        }


        public void RefreshCompanyExperienceDataGrid()
        {
            this.dgvExperienceDetails.Rows.Clear();

            foreach (var tempEdudata in this.ResumeDataWrapper.CompanyExperience)
            {
                this.dgvExperienceDetails.Rows.Add(tempEdudata.GetType()
                        .GetProperties()
                        .Select(p =>
                        {
                            object value = p.GetValue(tempEdudata, null);
                            if (p.PropertyType.ToString() == "System.DateTime")
                            {
                                return value == null ? string.Empty : UtilityService.DateFormatInDateMonthAndYear(value.ToString());
                            }
                            return value == null ? string.Empty : value.ToString();
                        })
                        .ToArray());

            }
            //  this.dgvEducationalData.DataSource=this.ResumeDataWrapper.EducationData;
        }


        public void RefreshSkillDetailsDataGrid()
        {
            this.dgvSkillData.Rows.Clear();

            foreach (var tempEdudata in this.ResumeDataWrapper.skillDetails)
            {
                this.dgvSkillData.Rows.Add(tempEdudata.GetType()
                        .GetProperties()
                        .Select(p =>
                        {
                            object value = p.GetValue(tempEdudata, null);
                            if (p.GetType().Equals("System.DateTime")) {
                                return value == null ? string.Empty : UtilityService.DateFormatInDateMonthAndYear(value.ToString());
                            }
                           
                            return value == null ? string.Empty : value.ToString();
                        })
                        .ToArray());
            }
            //  this.dgvEducationalData.DataSource=this.ResumeDataWrapper.EducationData;
        }


        public void RefreshProjectDetailsDataGrid()
        {
            this.dgvProjectDetails.Rows.Clear();
            foreach (var tempEdudata in this.ResumeDataWrapper.ProjectDetails)
            {
                this.dgvProjectDetails.Rows.Add(tempEdudata.GetType()
                        .GetProperties()
                        .Select(p =>
                        {
                            object value = p.GetValue(tempEdudata, null);
                            if (p.PropertyType.ToString() == "System.DateTime")
                            {
                                return value == null ? string.Empty : UtilityService.DateFormatInDateMonthAndYear(value.ToString());
                            }
                            return value == null ? string.Empty : value.ToString();
                        })
                        .ToArray());

            }
            //  this.dgvEducationalData.DataSource=this.ResumeDataWrapper.EducationData;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialogPicture.Multiselect = false;
            if (openFileDialogPicture.ShowDialog() == DialogResult.OK) {
                byte[] imageArray = System.IO.File.ReadAllBytes(openFileDialogPicture.FileName);
                CandidatePhoto = Convert.ToBase64String(imageArray);
                picCandidatePhoto.BackgroundImage = Image.FromFile(openFileDialogPicture.FileName);
            }
        }

        private void dgvProjectDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dgvEducationalData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 5 && MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        dgvEducationalData.Rows.RemoveAt(e.RowIndex);
            //        ResumeDataWrapper.EducationData.RemoveAt(e.RowIndex);
            //    }


            switch (e.ColumnIndex)
            {
                case 5:
                    FrmEducationDetails frm = new FrmEducationDetails();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.DataEntryForm = this;
                    frm.EditIndex = e.RowIndex;
                    frm.educationData = this.ResumeDataWrapper.EducationData[e.RowIndex];
                    frm.SetupEditData();
                    frm.ShowDialog();
                    break;
                case 6:

                    if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvProjectDetails.Rows.RemoveAt(e.RowIndex);
                        ResumeDataWrapper.EducationData.RemoveAt(e.RowIndex);
                        RefreshEducationDataGrid();
                    }
                    break;

            }
        }

        private void dgvProjectDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 6:
                    FrmProjectDetails frm = new FrmProjectDetails();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.DataEntryForm = this;
                    frm.EditIndex = e.RowIndex;
                    frm.projectDetails = this.ResumeDataWrapper.ProjectDetails[e.RowIndex];
                    frm.SetupEditData();
                    frm.ShowDialog();
                    break;
                case 7:

                    if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvProjectDetails.Rows.RemoveAt(e.RowIndex);
                        ResumeDataWrapper.ProjectDetails.RemoveAt(e.RowIndex);
                        RefreshProjectDetailsDataGrid();
                    }
                    break;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
    }
}
