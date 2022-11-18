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
        public ResumeDataService() {         
            _entityOperation=new EntityOperations<DtoResumeData>();
        }

        public int UpdateResumeData(DtoResumeData input) {
          return  _entityOperation.Save(input);
        }
    }
}
