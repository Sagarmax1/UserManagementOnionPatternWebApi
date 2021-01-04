using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Models.EntityFrameWorkCore;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private ApplicationDbContext _context;

        private DbSet<T> entities;
        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context; // Di
            this.entities = _context.Set<T>(); //DBSET is connecting to dbcontext for linking of user table and user profile table
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(long Id)
        {
            return entities.SingleOrDefault(t => t.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            entities.Add(entity); // ADD IN LOCAL MEMORY
            _context.SaveChanges(); // SAVE RECORD 
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");

            }
            _context.SaveChanges();
        }
    }
}
