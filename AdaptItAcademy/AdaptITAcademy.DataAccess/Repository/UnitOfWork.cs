using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICourseRepository Courses { get; private set; }
        public ITrainingRepository Trainings { get; private set; }
        private AdaptITAcademyContext _context;

        public UnitOfWork( AdaptITAcademyContext context) // inject via ITraining ICourse repos.
        {
            this._context = context;
            Courses =  new CourseRepostitory(context);
            Trainings = new TrainingRepository(context);
        }

        public void CommitDbChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
