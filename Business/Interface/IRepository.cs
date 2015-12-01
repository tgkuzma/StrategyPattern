using System.Collections.Generic;

namespace Business.Interface
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void SaveChanges(); 
    }
}