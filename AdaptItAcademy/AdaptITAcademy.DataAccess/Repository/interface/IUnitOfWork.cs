using AdaptITAcademy.DataAccess.Repository.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.DataAccess.Repository.@interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        ITrainingRepository Trainings { get; }
        IUserRepository Users { get; }
        IPostalAddressRepository   PostalAddresses { get; }
        IPhysicalAddressRepository PhysicalAddresses { get; }
        IUserTrainingRepository UsersTrainings { get; }
        void CommitDbChanges();
    }
}
