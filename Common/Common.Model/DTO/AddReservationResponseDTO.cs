using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.DTO
{
    public class AddReservationResponseDTO
    {
        public int ReservationId { get; set; }

        public UserDetailsModelDTO User { get; set; }

        public RoomDetailsResponseDTO Room { get; set; }
    }
}
