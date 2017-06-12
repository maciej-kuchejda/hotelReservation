using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.DTO
{
    public class SearchHotelRequestDTO
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int PersonsNumber { get; set; }

        public string Place { get; set; }

        public int NumberOfRooms { get; set; }
    }
}
