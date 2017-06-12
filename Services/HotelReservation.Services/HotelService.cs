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
                var result = SearchHotels(id.SearchRequest);
                if (result.Code != ResultActionModelCode.OK)
                    return new ResponseModel<HotelDetailsResponseDTO>() { Code = result.Code, Message = result.Message };
                var roomsIds = result.Data.Where(x => x.HotelId == id.HotelId).Select(x => x.RoomId).ToList();
                var hotel = _factory.GetUnitOfWork(UnitOfWorkContext.ReadOnly)
                    .GetRepository<Hotel>()
                    .AsQueryable()
                    .FirstOrDefault(x => x.Id == id.HotelId);
                var avaibleRooms = _factory.GetUnitOfWork(UnitOfWorkContext.ReadOnly)
                    .GetRepository<Room>()
                    .AsQueryable()
                    .Where(x => roomsIds.Contains(x.Id)).ToList();

                HotelDetailsResponseDTO response = new HotelDetailsResponseDTO()
                {
                    Description = hotel.Description,
                    HotelCity = hotel.City,
                    HotelContactPhone = hotel.ContactPhone,
                    HotelCountry = hotel.Country.Name,
                    HotelId = hotel.Id,
                    HotelName = hotel.Name,
                    HotelNumber = hotel.HouseNumber,
                    Rooms = avaibleRooms.Select(x => new RoomDetailsResponseDTO()
                    {
                        AdditionalInfo = x.AdditionalInfo,
                        Price = x.Price,
                        RoomId = x.Id,
                    }).ToList()
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
                    .Where(x => x.Name == dto.Place || x.Country.Name == dto.Place)
                    .SelectMany(x => x.Rooms)
                    .Where(x => x.PersonNumbers == dto.PersonsNumber &&
                            x.Reservations.All(z => !(z.DateFrom == dto.From && z.DateTo == dto.To)))
                    .Select(x => new SearchHotelResponseDTO() {
                        HotelId = x.Hotel.Id,
                        City = x.Hotel.City,
                        Country = x.Hotel.Country.Name,
                        HotelName = x.Hotel.Name,
                        Price = x.Price,
                    }).ToList();

                return ResponseModel<List<SearchHotelResponseDTO>>.OK(result);
            }
        }
    }
}
