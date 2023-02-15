using AdaptITAcademy.DataAccess.Repository.@interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.DataAccess.Repository.implementation
{
    public class AdaptItAcademyRepository<T> : IAdaptItAcademyGenericRepository<T> where T : class
    {
        private AdaptITAcademyContext _context;
        private DbSet<T> tableSet;

        public AdaptItAcademyRepository(AdaptITAcademyContext context)
        {
            _context = context;
            tableSet = _context.Set<T>();
        }
        public T Add(T entity)
        {
            tableSet.Add(entity);
            return entity;
        }

        public void Delete(object id)
        {
            var tableResult = tableSet.Find(id);
            tableSet.Remove(tableResult);
        }

        public List<T> GetAll()
        {
            return tableSet.ToList();
        }

        public T GetById(object id)
        {
            var tableResult = tableSet.Find(id);
            return tableResult;
        }

        public void Update(T entity)
        {
            _context.ChangeTracker.Clear();
            tableSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
