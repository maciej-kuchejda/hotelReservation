using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities
{
    public class Hotel : MainEntity
    {
        public string Name { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }

        [Required]
        public Country Country { get; set; }
        [Required]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
