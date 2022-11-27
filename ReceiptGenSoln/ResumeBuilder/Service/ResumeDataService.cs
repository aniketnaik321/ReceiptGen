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

        public ResumeDataService() {         
            _entityOperation=new EntityOperations<DtoResumeData>();
            _skillDetailsRepo=new EntityOperations<SkillDetails>();
            _companyExperienceRepo= new EntityOperations<CompanyExperience>();
            _educationData = new EntityOperations<EducationData>();
        }

        public int UpdateResumeData(DtoResumeData input) {
            if (input.Id == 0)
                return _entityOperation.Save(input);
            else
                return _entityOperation.Update(input,input.Id);
        }

        public ResumeDataWrapper LoadResumeData()
        {
            ResumeDataWrapper _wrapper = new ResumeDataWrapper();
            DtoResumeData resumeData= _entityOperation.FindById(1);

            if (resumeData != null) {
                SkillDetails skillDetails = _skillDetailsRepo.FindById(resumeData.Id);
                CompanyExperience companyExperiennce = _companyExperienceRepo.FindById(resumeData.Id);
                EducationData educationData = _educationData.FindById(resumeData.Id);
                if(educationData!=null)
                _wrapper.EducationData.Add( educationData);
                _wrapper.resumeData = resumeData;
                
            }
            return _wrapper;
        }
    }
}
