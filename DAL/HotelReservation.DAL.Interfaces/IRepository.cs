using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();

        T Find(params object[] keyValues);

        void Delete(T entity);
        void Add(T entity);
        void Attach(T entity);
    }
}
