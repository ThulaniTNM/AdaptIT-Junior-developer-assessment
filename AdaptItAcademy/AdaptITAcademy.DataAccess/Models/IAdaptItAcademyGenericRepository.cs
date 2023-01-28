using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess.Models
{
    internal interface IAdaptItAcademyGenericRepository<T> where T : class // might need to limit to only models.
    {
        List<T> GetAll();
        T GetById(Object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Object id);
    }
}
