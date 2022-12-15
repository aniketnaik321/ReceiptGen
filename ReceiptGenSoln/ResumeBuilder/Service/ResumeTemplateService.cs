using ResumeBuilder.DTO;
using ResumeBuilder.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Service
{
    public class ResumeTemplateService
    {
        IEntityOperations<DtoResumeTemplate> _entityOperation;

        public ResumeTemplateService()
        {
            _entityOperation = new EntityOperations<DtoResumeTemplate>();
        }


        public List<DtoResumeTemplate> GetTemplateList() {
            return _entityOperation.GetList();
        
        }


    }
}
