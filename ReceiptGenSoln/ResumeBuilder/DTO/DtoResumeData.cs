using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.DTO
{
    [Table("ResumeData")]
    public class DtoResumeData
    {
        [Column(name:"CandidateName")]
        public string CandidateName {get;set;}
        [Column(name: "ContactNo")]
        public string ContactNo { get; set; }
        [Column(name: "Address")]
        public string Address { get; set; }

        [Column(name: "EmailID")]
        public string EmailID { get; set; }
    }


    [Table("EducationData")]
    public class EducationData {
        [Column(name: "University")]
        public string Institute { get; set; }
        [Column(name: "FromDate")]
        public string FromDate { get; set; }
        [Column(name: "ToDate")]
        public string ToDate { get; set; }

        [Column(name: "PercentData")]
        public string PercentGrade { get; set; }

        [Column(name: "CandidateID")]
        public int CandidateID { get; set; }
    }

    [Table("CompanyData")]
    public class CompanyExperiennce
    {
        [Column(name: "CompanyName")]
        public string CompanyName { get; set; }
        [Column(name: "FromDate")]
        public DateTime FromDate { get; set; }
        [Column(name: "ToDate")]
        public DateTime ToDate { get; set; }

        [Column(name: "Experience")]
        public string Experience { get; set; }

        [Column(name: "CandidateID")]
        public int CandidateID { get; set; }

    }


    [Table("SkillData")]
    public class SkillDetails
    {
        [Column(name: "SkillName")]
        public string SkillName { get; set; }

        [Column(name:"SkillRating")]
        public float SkillRating { get; set; }
        [Column(name: "CandidateID")]
        public int CandidateID { get; set; }
    }


}
