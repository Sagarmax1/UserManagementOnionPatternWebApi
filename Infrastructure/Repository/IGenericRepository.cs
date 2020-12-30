using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long Id);
        void Insert(T entity);
        void update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
