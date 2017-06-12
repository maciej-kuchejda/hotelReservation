using HotelReservation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL.UnitOfWork
{
    public class ReadOnlyUnitofWork : IUnitOfWork
    {
        private readonly DbContext _objectContext;
        public ReadOnlyUnitofWork(DbContext objectContext)
        {
            _objectContext = objectContext;
        }
        public void Dispose()
        {
            if (_objectContext != null)
            {
                _objectContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            throw new Exception("SaveChanges in UnitOfWorkNoWork");
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new ReadonlyRepository<T>(_objectContext);
        }

        public void AutoDetectChanges(bool Enabled)
        {
            return;
        }
        public DbConnection GetConnection()
        {
            return _objectContext.Database.Connection;
        }
    }
}
