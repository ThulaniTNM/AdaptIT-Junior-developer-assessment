using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Business_Rules
{
    public interface ICourseTrainingService<R, W> // R = read, has id. W = write doesn't have id
    {
        void Add(W DTO);
        List<R> GetAll();
        R GetById(object id);
        void Update(object id, R DTO); // id required use R
        void Delete(object id);

        void SaveChanges();
    }
}
