using System.Collections.Generic;
using System.Linq;
using Business.Interface;

namespace Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly TestContext _context;

        protected RepositoryBase(TestContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}