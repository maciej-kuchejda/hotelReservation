using HotelReservation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWorkFactory _factory;

        public UserService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }


    }
}
