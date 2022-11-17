using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Entities
{
    [Table("ResumeData")]
    public class EtyResumeData
    {
        [Column(name: "CandidateName")]
        public string CandidateName { get; set; }

        [Column(name: "CandidateName")]
        public string ContactNo { get; set; }
        [Column(name: "CandidateName")]
        public string Address { get; set; }
        public string EmailID { get; set; }
    }

    public class EducationData
    {
        public string Institute { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string PercentGrade { get; set; }
    }

    public class CompanyExperience
    {
        public string CompanyName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string TotalExperience { get; set; }

    }


    public class SkillDetails
    {
        public string SkillName { get; set; }
        public int SkillRating { get; set; }
    }
}
