using HotelReservation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL.UnitOfWork
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _objectSet;

        public Repository(DbContext _objectContext)
        {
            _objectSet = _objectContext.Set<T>();
        }
        public IQueryable<T> AsQueryable()
        {
            return _objectSet;
        }

        public T Find(params object[] keyValues)
        {
            return _objectSet.Find(keyValues);
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }
    }
}
