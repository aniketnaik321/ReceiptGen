using ResumeBuilder.DTO;
using ResumeBuilder.Service;
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
    public partial class FrmAllCandidates : Form
    {

        private ResumeDataService resumeDataService;
        private string CandidateID;

        public FrmAllCandidates()
        {
            InitializeComponent();
        }

        private void FrmAllCandidates_Load(object sender, EventArgs e)
        {
            resumeDataService = new ResumeDataService();
            RefreshGrid();
        }

        private void RefreshGrid() {
            this.dgvCandidateDetails.Rows.Clear();
            foreach (var tempEdudata in this.resumeDataService.GetCandidateList())
            {
                this.dgvCandidateDetails.Rows.Add(tempEdudata.GetType()
                        .GetProperties()
                        .Select(p =>
                        {
                            object value = p.GetValue(tempEdudata, null);
                            return value == null ? string.Empty : value.ToString();
                        })
                        .ToArray());
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dgvCandidateDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            switch (e.ColumnIndex) {
                case 5:
                    {
                        FrmDataEntry frm = new FrmDataEntry();
                        frm.LoadCandidateData(Convert.ToInt32(dgvCandidateDetails.Rows[e.RowIndex].Cells[0].Value.ToString()));
                        frm.MdiParent = this.ParentForm;
                        frm.IsNew = true;
                        frm.Icon = this.Icon;
                        frm.Width = this.ParentForm.ClientSize.Width - 97;
                        frm.Height = this.ParentForm.ClientSize.Height - 30;
                        frm.Left = 0;
                        frm.Top = 0;
                        frm.WindowState = FormWindowState.Normal;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.Show();
                    }
                    break;
                case 6:
                    {
                        FrmResumeTemplates frm = new FrmResumeTemplates();                      
                        frm.MdiParent = this.ParentForm;                        
                        frm.Icon = this.Icon;
                        frm.Width = this.ParentForm.ClientSize.Width - 97;
                        frm.Height = this.ParentForm.ClientSize.Height - 30;
                        frm.Left = 0;
                        frm.Top = 0;
                        frm.CandidateID = Convert.ToInt32(dgvCandidateDetails.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frm.WindowState = FormWindowState.Normal;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.Show();
                    }
                    break;
            }
              

            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmDataEntry frm = new FrmDataEntry();
           // frm.LoadCandidateData(Convert.ToInt32(dgvCandidateDetails.Rows[e.RowIndex].Cells[0].Value.ToString()));
            frm.MdiParent = this.ParentForm;
            frm.IsNew = true;
            frm.Icon = this.Icon;
            frm.Width = this.ParentForm.ClientSize.Width - 97;
            frm.Height = this.ParentForm.ClientSize.Height - 30;
            frm.Left = 0;
            frm.Top = 0;
            frm.WindowState = FormWindowState.Normal;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
        }

        private void btnExportTOPDF_Click(object sender, EventArgs e)
        {

        }
    }
}
