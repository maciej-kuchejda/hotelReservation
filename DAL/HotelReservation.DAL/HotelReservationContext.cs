using HotelReservation.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL
{
    public partial class HotelReservationContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        public HotelReservationContext() : base("name=HotelReservationContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HotelReservationContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();// Remove 's' from tables name -> Accounts => Account
            modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
