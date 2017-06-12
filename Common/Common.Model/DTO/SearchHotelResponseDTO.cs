using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.DTO
{
    public class SearchHotelResponseDTO
    {
        public decimal Price { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
    }
}
