using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.DTO
{
    public class RoomDetailsResponseDTO
    {
        public int RoomId { get; set; }

        public decimal Price { get; set; }

        public string RoomName { get; set; }

        public string AdditionalInfo { get; set; }
    }
}
