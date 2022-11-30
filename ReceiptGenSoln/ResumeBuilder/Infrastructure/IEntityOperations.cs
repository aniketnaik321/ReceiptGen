using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Infrastructure
{
    public interface IEntityOperations<TEty>
    {
        List<TEty> GetList();
        int Save(TEty inp);
        TEty FindById(object id);
        int Update(TEty inp, object id);
        bool UpdateEntity(TEty inp, object id);
        bool Delete(object id);
        bool CustomQuery(string sql);
    }
}
