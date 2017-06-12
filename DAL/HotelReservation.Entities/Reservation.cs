using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities
{
    public class Reservation : MainEntity
    {
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public virtual Room Room { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
