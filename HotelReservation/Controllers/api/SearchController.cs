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
    public class SearchController : ApiController
    {
        private IHotelService _service;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public SearchController(IHotelService service)
        {
            _service = service;
        }

        [HttpGet]
        public HttpResponseMessage Search([FromUri]SearchHotelRequestDTO model)
        {
            try
            {
                var result = _service.SearchHotels(model);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                logger.Error(e, "Search");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
