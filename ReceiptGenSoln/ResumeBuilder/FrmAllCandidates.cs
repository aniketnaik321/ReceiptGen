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
    }
}
