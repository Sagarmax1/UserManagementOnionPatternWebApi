using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class GenericRepositorycs<T> : IGenericRepository<T> where T : BaseEntity
    {
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
