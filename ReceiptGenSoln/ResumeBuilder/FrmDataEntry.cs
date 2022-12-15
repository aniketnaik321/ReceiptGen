using ResumeBuilder.DTO;
using ResumeBuilder.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class FrmDataEntry : Form
    {

        private ResumeDataService _resumeDataService;
        public DtoResumeData ResumeData;
        private string CandidatePhoto;
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
            LoadCandidateData();
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
            //_rw.Tag=Guid.NewGuid().ToString();
            //var  index = dgvEducationalData.Rows.Add(_rw);
        }        

     /*   private void dgvEducationalData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dgvEducationalData.Rows[e.RowIndex];
            Console.WriteLine("Rows added");
            if (e.RowIndex != -1)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    if (cell.ColumnIndex == 2 || cell.ColumnIndex == 3)
                    {
                       var dateTimePicker = new DateTimePicker();
                        dateTimePicker.Font = new Font("Segoe UI", 9);
                        dateTimePicker.Name="dtp"+ row.Tag + "-" + cell.ColumnIndex.ToString();
                        dgvEducationalData.Controls.Add(dateTimePicker);
                        dateTimePicker.Format = DateTimePickerFormat.Short;
                        Rectangle oRectangle = dgvEducationalData.GetCellDisplayRectangle(cell.ColumnIndex, e.RowIndex, true);
                        dateTimePicker.Size = new Size(oRectangle.Width - 2, oRectangle.Height - 10);
                        dateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);
                    }
            }
        }*/

      

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
            if(e.ColumnIndex==5)
            if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                    //dgvEducationalData.Controls.RemoveByKey("dtp" + dgvEducationalData.Rows[e.RowIndex].Tag + "-2");
                    //dgvEducationalData.Controls.RemoveByKey("dtp" + dgvEducationalData.Rows[e.RowIndex].Tag + "-3");
                    //dgvEducationalData.Rows.RemoveAt(e.RowIndex);

                    //foreach (DataGridViewRow row in dgvEducationalData.Rows)
                    //{
                    //   // if (row.Index == e.RowIndex) continue;
                    //    int balancer = (row.Index >= e.RowIndex)?1:0;
                    //    foreach (DataGridViewCell cell in row.Cells)
                    //    {
                    //        if (new int[] { 2, 3 }.Any(T => T == cell.ColumnIndex))
                    //        {
                    //            Rectangle oRectangle = dgvEducationalData.GetCellDisplayRectangle(cell.ColumnIndex, row.Index, true);
                    //            DateTimePicker _control = (DateTimePicker)dgvEducationalData.Controls.Find("dtp" + row.Tag + "-" + cell.ColumnIndex.ToString(), false).First();
                    //            if (_control == null) continue;
                    //            _control.Size = new Size(oRectangle.Width - 2, oRectangle.Height - 10);
                    //            _control.Location = new Point(oRectangle.X, oRectangle.Y);
                    //        }
                    //    }
                    //}

                    ResumeDataWrapper.EducationData.RemoveAt(e.RowIndex);
                    dgvEducationalData.Rows.RemoveAt(e.RowIndex);

                }
        }

        private void btnAddExperienceDetails_Click(object sender, EventArgs e)
        {
            //DataGridViewRow _rw = new DataGridViewRow();
            //_rw.Tag = Guid.NewGuid().ToString();
            //dgvExperienceDetails.Rows.Add(_rw);

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
            if (e.ColumnIndex == 5)
                if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvExperienceDetails.Controls.RemoveByKey("dtp" + dgvExperienceDetails.Rows[e.RowIndex].Tag + "-1");
                    dgvExperienceDetails.Controls.RemoveByKey("dtp" + dgvExperienceDetails.Rows[e.RowIndex].Tag + "-2");
                    dgvExperienceDetails.Rows.RemoveAt(e.RowIndex);

                    foreach (DataGridViewRow row in dgvExperienceDetails.Rows)
                    {
                        // if (row.Index == e.RowIndex) continue;
                        int balancer = (row.Index >= e.RowIndex) ? 1 : 0;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (new int[] { 1, 2 }.Any(T => T == cell.ColumnIndex))
                            {
                                Rectangle oRectangle = dgvExperienceDetails.GetCellDisplayRectangle(cell.ColumnIndex, row.Index, true);
                                DateTimePicker _control = (DateTimePicker)dgvExperienceDetails.Controls.Find("dtp" + row.Tag + "-" + cell.ColumnIndex.ToString(), false).First();
                                if (_control == null) continue;
                                _control.Size = new Size(oRectangle.Width - 2, oRectangle.Height - 10);
                                _control.Location = new Point(oRectangle.X, oRectangle.Y);
                            }
                        }
                    }
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
            

           MessageBox.Show(_resumeDataService.UpdateResumeData(ResumeDataWrapper).ToString());
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

            //DataGridViewRow _rw = new DataGridViewRow();
            //_rw.Tag = Guid.NewGuid().ToString();
            //dgvSkillData.Rows.Add(_rw);
        }

        private void dgvSkillData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
                if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvSkillData.Rows.RemoveAt(e.RowIndex);
                }
        }

        private void btnProjectDetails_Click(object sender, EventArgs e)
        {
            FrmProjectDetails frm = new FrmProjectDetails();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.DataEntryForm = this;
            frm.ShowDialog();
        }

        private void LoadCandidateData() {
            ResumeDataWrapper= _resumeDataService.LoadResumeData();            
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
            FrmProjectDetails frm = new FrmProjectDetails();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.DataEntryForm = this;
            frm.EditIndex = e.RowIndex;
            frm.projectDetails = this.ResumeDataWrapper.ProjectDetails[e.RowIndex];
            frm.SetupEditData();
            frm.ShowDialog();
        }
    }
}
