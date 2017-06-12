using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork(UnitOfWorkContext Context);
    }
    public enum UnitOfWorkContext
    {
        Default,
        ReadOnly
    }
}
