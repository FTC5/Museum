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
    public class GrafikController : ApiController
    {
        IMapper mapper;
        IGrafikService grafikService;

        public GrafikController(IMapper mapper, IGrafikService grafikService)
        {
            this.mapper = mapper;
            this.grafikService = grafikService;
        }
        [HttpGet]
        public IHttpActionResult GetGrafiks()
        {
            
            var grafiks = mapper.Map<IEnumerable<GrafikModel>>(grafikService.GetGrafiks());
            return Ok(grafiks);
            
        }
        [HttpGet]
        public IHttpActionResult FindExpositionByGrafiks(string name)
        {
            var grafiks = mapper.Map<IEnumerable<GrafikModel>>(grafikService.FindByName(name));
            return Ok(grafiks);
        }
    }
}
