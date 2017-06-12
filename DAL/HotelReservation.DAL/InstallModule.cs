using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL
{
    public class InstallModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HotelReservationContext>().As<DbContext>();
        }
    }
}
