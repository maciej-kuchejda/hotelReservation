using Common.Model.DTO;
using Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public interface IReservationService
    {
        ResponseModel<AddReservationResponseDTO> AddReservation(AddReservationRequestDTO dto);

        ResponseModel UpdateReservation(UpdateReservationModelDTO dto);
    }
}
