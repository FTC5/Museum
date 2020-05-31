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
    public class CustomExcursionController : ApiController
    {
        IMapper mapper;
        IExcursionsScheduleService excursionsScheduleService;
        public CustomExcursionController(IMapper mapper, IExcursionsScheduleService excursionsScheduleService)
        {
            this.mapper = mapper;
            this.excursionsScheduleService = excursionsScheduleService;
        }
        [HttpGet]
        public IHttpActionResult GetCustomExcursions(int grafikId)
        {
            var excursions = mapper.Map<IEnumerable<CustomExcursionModel>>(excursionsScheduleService.GetCustomExcursions(grafikId));
            return Ok(excursions);
        }
        [HttpPost]
        public IHttpActionResult AddOnePerson(int excursionId,[FromBody] CustomerModel customer)
        {
            var customerDTO = mapper.Map<CustomerDTO>(customer);
            excursionsScheduleService.SignUpToCustomExcursion(excursionId, customerDTO);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult AddManyPerson(int excursionId, [FromBody] CustomerModel[] customers)
        {
            var customersDTO = mapper.Map<IEnumerable<CustomerDTO>>(customers);
            excursionsScheduleService.SignUpToCustomExcursion(excursionId, customersDTO);
            return Ok();
        }
    }
}
