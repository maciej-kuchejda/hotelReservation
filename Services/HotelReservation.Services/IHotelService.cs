using Common.Model.DTO;
using Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public interface IHotelService
    {
        ResponseModel<List<SearchHotelResponseDTO>> SearchHotels(SearchHotelRequestDTO dto);

        ResponseModel<HotelDetailsResponseDTO> GetDetails(SearchModelId id);
    }
}
