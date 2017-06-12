using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities
{
    public class User : MainEntity
    {
        [MaxLength(125)]
        public string FirstName { get; set; }
        [MaxLength(125)]
        public string LastName { get; set; }

        [Required]
        public virtual Country Country { get; set; }
    }
}
