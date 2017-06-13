using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }

    }
}
