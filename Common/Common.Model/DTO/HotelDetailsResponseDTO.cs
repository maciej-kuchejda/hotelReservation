using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.DTO
{
    public class HotelDetailsResponseDTO
    {
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string HotelCity { get; set; }

        public string HotelNumber { get; set; }

        public string HotelContactPhone { get; set; }

        public string HotelCountry { get; set; }

        public string Description { get; set; }

        public RoomDetailsResponseDTO Room  { get; set; }
    }
}
