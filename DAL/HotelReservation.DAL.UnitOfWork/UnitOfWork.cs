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
    public class UnitOfWork : IUnitOfWork
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly DbContext _objectContext;

        public UnitOfWork(DbContext dbContext)
        {
            _objectContext = dbContext;
            _objectContext.Configuration.LazyLoadingEnabled = true;
            _objectContext.Configuration.ProxyCreationEnabled = true;
            _objectContext.Configuration.AutoDetectChangesEnabled = true;
        }

        public void AutoDetectChanges(bool Enabled)
        {
            this._objectContext.Configuration.AutoDetectChangesEnabled = Enabled;
        }

        public void Dispose()
        {
            if (_objectContext != null)
            {
                _objectContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_objectContext);
        }

        public int SaveChanges()
        {
            return _objectContext.SaveChanges();
        }

        public DbConnection GetConnection()
        {
            return _objectContext.Database.Connection;
        }
    }
}
