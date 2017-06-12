using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities
{
    public class Opinion : MainEntity
    {
        public DateTime AddDate { get; set; }

        public string Text { get; set; }

        [Range(0,10)]
        public int Rating { get; set; }
        [Required]
        public virtual Hotel Hotel { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
