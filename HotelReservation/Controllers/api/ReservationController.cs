using Common.Model.DTO;
using HotelReservation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelReservation.Controllers.api
{
    public class ReservationController : ApiController
    {
        private IHotelService _service;
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private IReservationService _reservationService;

        public ReservationController(IHotelService service,IReservationService reservationService)
        {
            _service = service;
            _reservationService = reservationService;
        }

        [HttpGet]
        public HttpResponseMessage GetDetails([FromUri]SearchModelId model)
        {
            try
            {
                var result =  _service.GetDetails(model);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _logger.Error(e, "GetDetails");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpPost]
        public HttpResponseMessage AddReservation(AddReservationRequestDTO model)
        {
            try
            {
                var result = _reservationService.AddReservation(model);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                _logger.Error(e, "GetDetails");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
