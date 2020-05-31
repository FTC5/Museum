using AutoMapper;
using Museum.BLL.DTO;
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
        public IHttpActionResult UpdateExposition([FromBody]ExpositionModel exposition)
        {
            var expositionDTO = mapper.Map<ExpositionDTO>(exposition);
            expositionService.UpdateExposition(expositionDTO);

            return Ok();
        }
        [HttpPost]
        public IHttpActionResult AddExposition([FromBody]ExpositionModel exposition)
        {
            var expositionDTO = mapper.Map<ExpositionDTO>(exposition);
            expositionService.AddExposition(expositionDTO);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteExposition(int Id)
        {
            expositionService.DeleteExposition(Id);
            return Ok();
        }
    }
}
