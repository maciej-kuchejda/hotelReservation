using Autofac;
using HotelReservation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL.UnitOfWork
{
    public class InstallModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>();
        }
    }
}
