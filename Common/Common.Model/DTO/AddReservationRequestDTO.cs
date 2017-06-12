using HotelReservation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.DTO
{
    public class AddReservationRequestDTO
    {
        public int RoomId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public ReservationPhase Phase { get; set; }

        public UserModelDTO UserDTO { get; set; }
    }
}
