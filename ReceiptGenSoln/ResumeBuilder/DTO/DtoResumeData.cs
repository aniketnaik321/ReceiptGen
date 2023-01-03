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
        public int Id { get; set; }

        [Column(name:"CandidateName")]
        public string CandidateName {get;set;}
        [Column(name: "ContactNo")]
        public string ContactNo { get; set; }
        [Column(name: "Address")]
        public string Address { get; set; }

        [Column(name: "EmailID")]
        public string EmailID { get; set; }

        [Column(name: "Hobbies")]
        public string Hobbies { get; set; }

        [Column(name: "Portfolio")]
        public string Portfolio { get; set; }

        [Column(name: "DeclarationText")]
        public string DeclarationText { get; set; }

        [Column(name: "ResumeTitle")]
        public string ResumeTitle { get; set; }

        [Column(name: "ResumeSummary")]
        public string ResumeSummary { get; set; }

        [Column(name: "CandidatePhoto")]
        public string CandidatePhoto { get; set; }
    }


    [Table("EducationData")]
    public class EducationData {

        [Column(name: "Specification")]
        public string Specification { get; set; }
        [Column(name: "University")]
        public string University { get; set; }

        [Column(name: "FromDate")]
        public DateTime FromDate { get; set; }
        [Column(name: "ToDate")]
        public DateTime ToDate { get; set; }

        [Column(name: "PercentData")]
        public string PercentData { get; set; }

        [Column(name: "CandidateID")]
        public int CandidateID { get; set; }
    }

    [Table("CompanyData")]
    public class CompanyExperience
    {
        [Column(name: "CompanyName")]
        public string CompanyName { get; set; }
        [Column(name: "FromDate")]
        public DateTime FromDate { get; set; }
        [Column(name: "ToDate")]
        public DateTime ToDate { get; set; }


        [Column(name: "Designation")]
        public string Designation { get; set; }

        [Column(name: "CurrentlyWorking")]
        public bool CurrentlyWorking { get; set; }

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


        [Column(name: "SkillExperience")]
        public string SkillExperience { get; set; }

        [Column(name: "CandidateID")]
        public int CandidateID { get; set; }
    }

    [Table("ProjectData")]
    public class ProjectDetails
    {
        [Column(name: "ProjectName")]
        public string ProjectName { get; set; }

        [Column(name: "ClientName")]
        public string ClientName { get; set; }

        [Column(name: "Description")]
        public string Description { get; set; }

        [Column(name: "RoleInProject")]
        public string RoleInProject { get; set; }

        [Column(name: "FromDate")]
        public DateTime FromDate { get; set; }

        [Column(name: "ToDate")]
        public DateTime ToDate { get; set; }        

        [Column(name: "CandidateID")]
        public int CandidateID { get; set; }
    }


    public class ResumeDataWrapper {
        public DtoResumeData resumeData {get;set;}
        public List<SkillDetails> skillDetails { get; set; }
        public List<CompanyExperience> CompanyExperience { get; set; }
        public List<EducationData> EducationData { get; set; }
        public List<ProjectDetails> ProjectDetails { get; set; }
    }   


}
