using HotelReservation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL.UnitOfWork
{
    public class ReadonlyRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _objectSet;

        public ReadonlyRepository(DbContext objectContext)
        {
            _objectSet = objectContext.Set<T>();
        }

        public IQueryable<T> AsQueryable()
        {
            return _objectSet.AsNoTracking();
        }


        public T Find(params object[] keyValues)
        {
            return _objectSet.Find(keyValues);
        }

        public void Delete(T entity)
        {
            throw new Exception("Delete in ReadonlyRepository");
        }

        public void Add(T entity)
        {
            throw new Exception("Add in ReadonlyRepository");
        }

        public void Attach(T entity)
        {
            throw new Exception("Attach in ReadonlyRepository");
        }
    }
}
