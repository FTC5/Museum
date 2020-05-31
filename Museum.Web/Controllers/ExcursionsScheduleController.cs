using AutoMapper;
using Museum.BLL.Interfaces;
using Museum.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Museum.Web.Controllers
{
    public class ExcursionsScheduleController : ApiController
    {
        IMapper mapper;
        IExcursionsScheduleService excursionsScheduleService;

        public ExcursionsScheduleController(IMapper mapper, IExcursionsScheduleService excursionsScheduleService)
        {
            this.mapper = mapper;
            this.excursionsScheduleService = excursionsScheduleService;
        }
        [HttpGet]
        public IHttpActionResult GetScheduledExcursionInfo(int grafikId)
        {
            var scheduledExcursion = mapper.Map<ExcursionModel>(
                excursionsScheduleService.GetScheduledExcursionsInfo(grafikId));
            return Ok(scheduledExcursion);
        }
    }
}
