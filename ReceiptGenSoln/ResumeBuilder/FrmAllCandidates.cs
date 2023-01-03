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
         
                if (e.ColumnIndex == 5)
                    if (MessageBox.Show("Confirm removing row?", "Easy Resume Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                    MessageBox.Show(dgvCandidateDetails.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        } 
    }
}
