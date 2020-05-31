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
    public class ExpositionController : ApiController
    {
        IMapper mapper;
        IExpositionService expositionService;

        public ExpositionController(IMapper mapper, IExpositionService expositionService)
        {
            this.mapper = mapper;
            this.expositionService = expositionService;
        }
        [HttpGet]
        public IHttpActionResult GetExposition(int id)
        {
            var exposition = mapper.Map<ExpositionModel>(expositionService.GetExpositionInfo(id));
            return Ok(exposition);
        }
        [HttpPut]
        public IHttpActionResult AddExposition([FromBody]ExpositionModel exposition)
        {
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteExposition([FromBody]ExpositionModel exposition)
        {
            return Ok();
        }
    }
}
