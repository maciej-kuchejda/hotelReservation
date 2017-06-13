using HotelReservation.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DAL
{
    public class HotelReservationInitializer : DropCreateDatabaseIfModelChanges<HotelReservationContext>
    {
        protected override void Seed(HotelReservationContext context)
        {
            var c1 = new Country() { Name = "Polska" };
            var c2 = new Country() { Name = "Ukraina" };
            context.Countries.Add(c1);
            context.Countries.Add(c2);
            context.SaveChanges();
            var h1 = new Hotel()
            {
                CountryId = c1.Id,
                City = "Warszawa",
                Country = c1,
                ContactPhone = "888-888-888",
                Description = "<h3>Opis</h3>",
                HouseNumber = "25",
                Name = "Hotel Prezydencki",
                PostalCode = "11-111",
                Street = "Warszwska",
            };
            var h2 = new Hotel()
            {
                CountryId = c1.Id,
                City = "Krakow",
                Country = c1,
                ContactPhone = "888-888-888",
                Description = "<h3>Opis</h3>",
                HouseNumber = "25",
                Name = "Hotel Wawelski",
                PostalCode = "11-111",
                Street = "Konopnickiej",
            };
            var h3 = new Hotel()
            {
                CountryId = c2.Id,
                City = "Kijów",
                Country = c2,
                ContactPhone = "888-888-888",
                Description = "<h3>Opis</h3>",
                HouseNumber = "25",
                Name = "Hotel Kijów",
                PostalCode = "11-111",
                Street = "Kijowska",
            }; var h4 = new Hotel()
            {
                CountryId = c2.Id,
                City = "Kijów",
                Country = c2,
                ContactPhone = "888-888-888",
                Description = "<h3>Opis</h3>",
                HouseNumber = "25",
                Name = "Hotel Kijowiak",
                PostalCode = "11-111",
                Street = "Kiejna",
            };
            context.Hotels.Add(h1);
            context.Hotels.Add(h2);
            context.Hotels.Add(h3);
            context.Hotels.Add(h4);
            context.SaveChanges();
            for (int i = 0; i < 20; i++)
            {
                var r1 = new Room()
                {
                    AdditionalInfo = "",
                    Hotel = h1,
                    PersonNumbers = i+1,
                    Price = 200 + i,
                    RoomType = RoomType.Standard
                };
                context.Rooms.Add(r1);
            }
            context.SaveChanges();
        }
    }
}
