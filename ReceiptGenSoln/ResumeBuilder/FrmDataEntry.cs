using ResumeBuilder.DTO;
using ResumeBuilder.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
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
        private DtoResumeData _resumeData;

        public FrmDataEntry()
        {
            InitializeComponent();     
            _resumeDataService = new ResumeDataService();
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

            DataGridViewRow _rw = new DataGridViewRow();
            _rw.Tag=Guid.NewGuid().ToString();
          var  index = dgvEducationalData.Rows.Add(_rw);
        }        

        private void dgvEducationalData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
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
        }

        private void FrmDataEntry_Load(object sender, EventArgs e)
        {
          
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex) {
                case 0:
                    break;
                case 1:
                    if (dgvEducationalData.Rows.Count == 0)
                    {
                        DataGridViewRow _rw = new DataGridViewRow();
                        _rw.Tag = Guid.NewGuid().ToString();
                        dgvEducationalData.Rows.Add(_rw);
                    }
                    break;
                case 2:
                    if (dgvExperienceDetails.Rows.Count == 0)
                        btnAddExperienceDetails_Click(sender, e);                    
                    break;

                case 3:
                    if (dgvSkillData.Rows.Count == 0)
                        btnAddSkill_Click(sender, e);
                    break;                   
            }
        }

        private void dgvEducationalData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==5)
            if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                    dgvEducationalData.Controls.RemoveByKey("dtp" + dgvEducationalData.Rows[e.RowIndex].Tag + "-2");
                    dgvEducationalData.Controls.RemoveByKey("dtp" + dgvEducationalData.Rows[e.RowIndex].Tag + "-3");
                    dgvEducationalData.Rows.RemoveAt(e.RowIndex);

                    foreach (DataGridViewRow row in dgvEducationalData.Rows)
                    {
                       // if (row.Index == e.RowIndex) continue;
                        int balancer = (row.Index >= e.RowIndex)?1:0;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (new int[] { 2, 3 }.Any(T => T == cell.ColumnIndex))
                            {
                                Rectangle oRectangle = dgvEducationalData.GetCellDisplayRectangle(cell.ColumnIndex, row.Index, true);
                                DateTimePicker _control = (DateTimePicker)dgvEducationalData.Controls.Find("dtp" + row.Tag + "-" + cell.ColumnIndex.ToString(), false).First();
                                if (_control == null) continue;
                                _control.Size = new Size(oRectangle.Width - 2, oRectangle.Height - 10);
                                _control.Location = new Point(oRectangle.X, oRectangle.Y);
                            }
                        }
                    }
                }
        }

        private void btnAddExperienceDetails_Click(object sender, EventArgs e)
        {
            DataGridViewRow _rw = new DataGridViewRow();
            _rw.Tag = Guid.NewGuid().ToString();
            dgvExperienceDetails.Rows.Add(_rw);
        }

        private void dgvExperienceDetails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = dgvExperienceDetails.Rows[e.RowIndex];            
            if (e.RowIndex != -1)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    if (cell.ColumnIndex == 1|| cell.ColumnIndex == 2)
                    {
                        var dateTimePicker = new DateTimePicker();
                        dateTimePicker.Font = new Font("Segoe UI", 9);
                        dateTimePicker.Name = "dtp" + row.Tag + "-" + cell.ColumnIndex.ToString();
                        dgvExperienceDetails.Controls.Add(dateTimePicker);
                        dateTimePicker.Format = DateTimePickerFormat.Short;
                        Rectangle oRectangle = dgvExperienceDetails.GetCellDisplayRectangle(cell.ColumnIndex, e.RowIndex, true);
                        dateTimePicker.Size = new Size(oRectangle.Width - 2, oRectangle.Height - 10);
                        dateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);
                    }
            }
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
            _resumeData = new DtoResumeData();
            _resumeData.ContactNo = txtContactNo.Text;
            _resumeData.EmailID = txtEmail.Text;
            _resumeData.Address = txtAddress.Text;
            _resumeData.CandidateName = txtName.Text;
            _resumeData.Hobbies = txtHobbies.Text;
            _resumeData.DeclarationText = txtDeclarationText.Text;
            _resumeData.Portfolio = txtPortfolio.Text;

           MessageBox.Show(_resumeDataService.UpdateResumeData(_resumeData).ToString());
        }

        private void btnAddSkill_Click(object sender, EventArgs e)
        {
            if (dgvSkillData.Rows.Count > 6)
            {
                MessageBox.Show("Skill details is restricted to 7 entries only", "Easy Resume Builder",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow _rw = new DataGridViewRow();
            _rw.Tag = Guid.NewGuid().ToString();
            dgvSkillData.Rows.Add(_rw);
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
            FrmProjectDetails _frm = new FrmProjectDetails();
            _frm.ShowDialog();
        }
    }
}
