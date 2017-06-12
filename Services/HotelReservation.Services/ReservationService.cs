using HotelReservation.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model.DTO;
using Common.Model.Response;
using HotelReservation.Entities;

namespace HotelReservation.Services
{
    public class ReservationService : IReservationService
    {
        private IUnitOfWorkFactory _factory;
        public ReservationService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public ResponseModel<AddReservationResponseDTO> AddReservation(AddReservationRequestDTO dto)
        {
            if (dto == null || dto.UserDTO == null)
                return new ResponseModel<AddReservationResponseDTO>() { Code = ResultActionModelCode.NoData, Message = "No data" };

            using (var unity = _factory.GetUnitOfWork(UnitOfWorkContext.Default))
            {
                var room = unity.GetRepository<Room>().AsQueryable()
                    .FirstOrDefault(x => x.Id == dto.RoomId);
                if (room == null)
                    return new ResponseModel<AddReservationResponseDTO>() { Code = ResultActionModelCode.NoEntityFound, Message = "No enetity found" };
                var user = unity.GetRepository<User>().AsQueryable()
                    .FirstOrDefault(x => x.Id == dto.UserDTO.Id);
                var reservation = new Reservation()
                {
                    DateFrom = dto.From,
                    DateTo = dto.To,
                    Phase = ReservationPhase.InsertedInformation,
                    Room = room,
                    Type = ReservationType.Normal,
                    User = user
                };
                unity.GetRepository<Reservation>()
                    .Add(reservation);
                unity.SaveChanges();
                AddReservationResponseDTO result = new AddReservationResponseDTO()
                {
                    ReservationId = reservation.Id,
                    Room = new RoomDetailsResponseDTO()
                    {
                        RoomId = room.Id,
                        Price = room.Price,
                    },
                    User = new UserDetailsModelDTO()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    } 
                };

                return ResponseModel<AddReservationResponseDTO>.OK(result);
            }
        }

        public ResponseModel UpdateReservation(UpdateReservationModelDTO dto)
        {
            if (dto == null)
                return new ResponseModel() { Code = ResultActionModelCode.NoData, Message = "No data" };

            using (var unity = _factory.GetUnitOfWork(UnitOfWorkContext.Default))
            {
                var reservation = unity.GetRepository<Reservation>().AsQueryable()
                    .FirstOrDefault(x => x.Id == dto.ReservationId);
                if (reservation == null)
                    return new ResponseModel() { Code = ResultActionModelCode.NoEntityFound, Message = "No entity found" };
                reservation.Phase = dto.Phase;
                unity.SaveChanges();
                return ResponseModel.OK();
            }
        }
    }
}
