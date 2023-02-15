using AdaptITAcademy.DataAccess.Repository.@interface;
using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.DataAccess.Repository.implementation
{
    public class TrainingRepository : AdaptItAcademyRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(AdaptITAcademyContext context) : base(context)
        {
        }
    }
}
