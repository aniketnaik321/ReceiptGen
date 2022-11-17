using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Infrastructure
{
    public interface IEntityOperations<TDto,TEty>
    {
        List<TDto> GetList();
        bool Save(TDto inp);
        TDto FindById(object id);
        bool Update(TDto inp, object id);
        bool UpdateEntity(TEty inp, object id);
        bool Delete(object id);
        IQueryable<TEty> GetAll();
    }
}
