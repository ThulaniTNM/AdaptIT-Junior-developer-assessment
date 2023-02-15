using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.DataAccess.Repository.@interface
{
    public interface IAdaptItAcademyGenericRepository<T> where T : class // might need to limit to only models.
    {
        List<T> GetAll();
        T GetById(object id);
        T Add(T entity);
        void Update(T entity);
        void Delete(object id);
    }
}
