using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.DTO
{
    public class SearchModelId
    {
        public int HotelId { get; set; }

        public SearchHotelRequestDTO SearchRequest { get; set; }
    }
}
