using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model.DTO;
using Common.Model.Response;
using HotelReservation.DAL.Interfaces;
using HotelReservation.Entities;

namespace HotelReservation.Services
{
    public class HotelService : IHotelService
    {
        private IUnitOfWorkFactory _factory;

        public HotelService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public ResponseModel<HotelDetailsResponseDTO> GetDetails(SearchModelId id)
        {
            if (id == null)
                return new ResponseModel<HotelDetailsResponseDTO>() { Code = ResultActionModelCode.NoData, Message = "No data" };

            using (var unity = _factory.GetUnitOfWork(UnitOfWorkContext.ReadOnly))
            {
                var room = _factory.GetUnitOfWork(UnitOfWorkContext.ReadOnly)
                    .GetRepository<Room>()
                    .AsQueryable()
                    .FirstOrDefault(x => x.Id == id.RoomId);
                var hotel = room.Hotel;
                

                HotelDetailsResponseDTO response = new HotelDetailsResponseDTO()
                {
                    Description = hotel.Description,
                    HotelCity = hotel.City,
                    HotelContactPhone = hotel.ContactPhone,
                    HotelCountry = hotel.Country.Name,
                    HotelId = hotel.Id,
                    HotelName = hotel.Name,
                    HotelNumber = hotel.HouseNumber,
                    Room = new RoomDetailsResponseDTO()
                    {
                        AdditionalInfo = room.AdditionalInfo,
                        Price = room.Price,
                        RoomId = room.Id,
                    }
                };
                return ResponseModel<HotelDetailsResponseDTO>.OK(response);
            }
        }

        public ResponseModel<List<SearchHotelResponseDTO>> SearchHotels(SearchHotelRequestDTO dto)
        {
            if (dto == null)
                return new ResponseModel<List<SearchHotelResponseDTO>>() { Code = ResultActionModelCode.NoData, Message = "No data" };
            using (var unity = _factory.GetUnitOfWork(UnitOfWorkContext.ReadOnly))
            {
                var result = unity.GetRepository<Hotel>()
                    .AsQueryable()
                    .Where(x => x.Name == dto.Place || x.Country.Name == dto.Place || x.City == dto.Place)
                    .SelectMany(x => x.Rooms)
                    .Where(x => x.PersonNumbers == dto.PersonsNumber &&
                            (x.Reservations.All(z => !(z.DateFrom == dto.From && z.DateTo == dto.To || x.Reservations.Count == 0))))
                    .Select(x => new SearchHotelResponseDTO() {
                        HotelId = x.Hotel.Id,
                        City = x.Hotel.City,
                        Country = x.Hotel.Country.Name,
                        HotelName = x.Hotel.Name,
                        Price = x.Price,
                        RoomId = x.Id
                    }).ToList();

                return ResponseModel<List<SearchHotelResponseDTO>>.OK(result);
            }
        }
    }
}
