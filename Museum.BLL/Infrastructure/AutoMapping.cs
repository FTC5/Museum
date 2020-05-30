using AutoMapper;
using Museum.BLL.DTO;
using Museum.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Infrastructure
{
    class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<Person, PersonDTO>()
                .Include<Guide, GuideDTO>()
                .Include<Customer,CustomerDTO>(); 
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Guide, GuideDTO>();
            CreateMap<Guide, GuideDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomExcursion, CustomExcursionDTO>();
            CreateMap<CustomExcursion, CustomExcursionDTO>().ReverseMap();
            CreateMap<Excursion, ExcursionDTO>();
            CreateMap<Excursion, ExcursionDTO>().ReverseMap();
            CreateMap<ExcursionsSchedule, ExcursionsScheduleDTO>();
            CreateMap<ExcursionsSchedule, ExcursionsScheduleDTO>().ReverseMap();
            CreateMap<Exposition, ExpositionDTO>();
            CreateMap<Exposition, ExpositionDTO>().ReverseMap();
            CreateMap<Grafik, GrafikDTO>();
            CreateMap<Grafik, GrafikDTO>().ReverseMap();
        }
    }
}
