using ResumeBuilder.DTO;
using ResumeBuilder.Infrastructure;
using ResumeBuilder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Service
{
    public class ResumeDataService
    {
        IEntityOperations<DtoResumeData> _entityOperation;
        IEntityOperations<SkillDetails> _skillDetailsRepo;
        IEntityOperations<CompanyExperience> _companyExperienceRepo;
        IEntityOperations<EducationData> _educationData;
        IEntityOperations<ProjectDetails> _projectDetails;

        public ResumeDataService() {         
            _entityOperation=new EntityOperations<DtoResumeData>();
            _skillDetailsRepo=new EntityOperations<SkillDetails>();
            _companyExperienceRepo= new EntityOperations<CompanyExperience>();
            _educationData = new EntityOperations<EducationData>();
            _projectDetails = new EntityOperations<ProjectDetails>();
        }


        public List<DtoResumeData> GetCandidateList() {
            return _entityOperation.GetList();
        }

        public int UpdateResumeData(ResumeDataWrapper input) {
            int candidateID=0;
            if (input.resumeData.Id == 0)
            {
                candidateID= _entityOperation.Save(input.resumeData);
                foreach (var item in input.skillDetails) {
                    item.CandidateID = candidateID;
                    _skillDetailsRepo.Save(item);   
                }

                foreach (var item in input.ProjectDetails)
                {
                    item.CandidateID = candidateID;
                    _projectDetails.Save(item);
                }

                foreach (var item in input.EducationData)
                {
                    item.CandidateID = candidateID;
                    _educationData.Save(item);
                }

                foreach (var item in input.CompanyExperience)
                {
                    item.CandidateID = candidateID;
                    _companyExperienceRepo.Save(item);
                }
            }
            else
            {
                 _entityOperation.Update(input.resumeData,input.resumeData.Id);
                candidateID = input.resumeData.Id;
                _skillDetailsRepo.CustomQuery("delete from EducationData where CandidateID="+candidateID.ToString());
                _skillDetailsRepo.CustomQuery("delete from ProjectData where CandidateID=" + candidateID.ToString());
                _skillDetailsRepo.CustomQuery("delete from SkillData where CandidateID=" + candidateID.ToString());
                _skillDetailsRepo.CustomQuery("delete from CompanyData where CandidateID=" + candidateID.ToString());
                _projectDetails.Delete(candidateID);
                foreach (var item in input.skillDetails)
                {
                    item.CandidateID = candidateID;
                    _skillDetailsRepo.Save(item);
                }

                foreach (var item in input.ProjectDetails)
                {
                    item.CandidateID = candidateID;
                    _projectDetails.Save(item);
                }

                foreach (var item in input.EducationData)
                {
                    item.CandidateID = candidateID;
                    _educationData.Save(item);
                }

                foreach (var item in input.CompanyExperience)
                {
                    item.CandidateID = candidateID;
                    _companyExperienceRepo.Save(item);
                }


                // return _entityOperation.Update(input.resumeData, input.resumeData.Id);
            }

            return candidateID;
        }

        public ResumeDataWrapper LoadResumeData(int CandidateID)
        {
            ResumeDataWrapper _wrapper = new ResumeDataWrapper() {
                EducationData = new List<EducationData>(),
                skillDetails=new List<SkillDetails>(),
                CompanyExperience=new List<CompanyExperience>(),
                ProjectDetails=new List<ProjectDetails>()
            };
            DtoResumeData resumeData= _entityOperation.FindById(1);
            if (resumeData != null) {
                SkillDetails skillDetails = _skillDetailsRepo.FindById(resumeData.Id);
                List<CompanyExperience> companyExperiennce = _companyExperienceRepo.GetList()?.Where(T=>T.CandidateID== CandidateID).ToList();
                List<SkillDetails> skillDetail = _skillDetailsRepo.GetList()?.Where(T => T.CandidateID == CandidateID).ToList();
                List<EducationData> eduDetails = _educationData.GetList()?.Where(T => T.CandidateID == CandidateID).ToList();
                List<ProjectDetails> projectData = _projectDetails.GetList()?.Where(T => T.CandidateID == CandidateID).ToList();
                // if (educationData!=null)
                _wrapper.EducationData= eduDetails?? new List<EducationData>();
                _wrapper.skillDetails = skillDetail ?? new List<SkillDetails>();
                _wrapper.CompanyExperience = companyExperiennce ?? new List<CompanyExperience>();
                _wrapper.ProjectDetails = projectData ?? new List<ProjectDetails>();
                _wrapper.resumeData = resumeData;                
            }
            return _wrapper;
        }
    }
}
