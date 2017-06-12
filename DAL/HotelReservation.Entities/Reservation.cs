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

        [Required]
        public ReservationPhase Phase { get; set; }

        [Required]
        public ReservationType Type { get; set; }
    }
    public enum ReservationPhase
    {
        Unknown = 0,
        InsertedInformation = 1,
        CheckedSummary = 2,
        Canceled = 3
    }
    public enum ReservationType
    {
        Normal = 1,
        Deleted = 2,
    }
}
