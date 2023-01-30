using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Business_Rules
{
    public interface IRules<T>
    {
        void Add(T DTO);
        List<T> GetAll();
        T GetById(object id);
        void Update(object id, T DTO);
        void Delete(object id);
    }
}
