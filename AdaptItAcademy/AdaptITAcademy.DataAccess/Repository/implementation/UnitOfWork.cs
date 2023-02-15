using AdaptITAcademy.DataAccess.Repository.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.DataAccess.Repository.implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICourseRepository Courses { get; private set; }
        public ITrainingRepository Trainings { get; private set; }
        public IUserRepository Users { get; private set; }

        public IPostalAddressRepository PostalAddresses { get; private set; }

        public IPhysicalAddressRepository PhysicalAddresses { get; private set; }
        public IUserTrainingRepository UsersTrainings { get; private set; }

        private AdaptITAcademyContext _context;

        public UnitOfWork(AdaptITAcademyContext context)
        {
            _context = context;
            Courses = new CourseRepostitory(context);
            Trainings = new TrainingRepository(context);
            Users = new UserRepository(context);
            PostalAddresses = new PostalAddressRepository(context);
            PhysicalAddresses = new PhysicalAddressRepository(context);
            UsersTrainings = new UserTrainingRepository(context);
        }

        public void CommitDbChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
