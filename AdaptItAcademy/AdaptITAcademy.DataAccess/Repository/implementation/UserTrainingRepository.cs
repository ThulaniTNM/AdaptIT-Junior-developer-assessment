using AdaptITAcademy.DataAccess.Repository.@interface;
using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.DataAccess.Repository.implementation
{
    public class UserTrainingRepository : AdaptItAcademyRepository<UserTraining>, IUserTrainingRepository
    {
        private AdaptITAcademyContext _context;
        public UserTrainingRepository(AdaptITAcademyContext context) : base(context)
        {
            _context = context;
        }

    }
}
