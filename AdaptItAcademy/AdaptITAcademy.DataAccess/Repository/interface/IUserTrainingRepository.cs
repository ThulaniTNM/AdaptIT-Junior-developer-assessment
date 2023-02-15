﻿using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.DataAccess.Repository.@interface
{
    public interface IUserTrainingRepository : IAdaptItAcademyGenericRepository<UserTraining>
    {
        AdaptITAcademyContext RetrieveContextInUse(); // for retrieve context in registering delegate service.
    }
}
