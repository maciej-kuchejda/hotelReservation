using HotelReservation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly Func<DbContext> contextFactory;

        public UnitOfWorkFactory(Func<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public IUnitOfWork GetUnitOfWork(UnitOfWorkContext Context)
        {
            switch (Context)
            {
                case UnitOfWorkContext.Default:
                    return new UnitOfWork(contextFactory());
                case UnitOfWorkContext.ReadOnly:
                    return new ReadOnlyUnitofWork(contextFactory());
                default:
                    throw new Exception("Unknown UnitOfWorkContext");
            }
        }
    }
}
