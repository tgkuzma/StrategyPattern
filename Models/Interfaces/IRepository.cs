﻿using System.Collections.Generic;

namespace Models.Interfaces
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