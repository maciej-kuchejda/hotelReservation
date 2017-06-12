using HotelReservation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.DTO
{
    public class UpdateReservationModelDTO
    {
        public int ReservationId { get; set; }

        public ReservationPhase Phase { get; set; }
    }
}
