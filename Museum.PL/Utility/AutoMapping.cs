using AutoMapper;
using Museum.BLL.DTO;
using Museum.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL.Utility
{
    class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<PersonModel, PersonDTO>()
                .Include<GuideModel, GuideDTO>()
                .Include<CustomerModel, CustomerDTO>(); 
            CreateMap<PersonModel, PersonDTO>().ReverseMap();
            CreateMap<GuideModel, GuideDTO>();
            CreateMap<GuideModel, GuideDTO>().ReverseMap();
            CreateMap<CustomerModel, CustomerDTO>();
            CreateMap<CustomerModel, CustomerDTO>().ReverseMap();
            CreateMap<CustomExcursionModel, CustomExcursionDTO>();
            CreateMap<CustomExcursionModel, CustomExcursionDTO>().ReverseMap();
            CreateMap<ExcursionModel, ExcursionDTO>();
            CreateMap<ExcursionModel, ExcursionDTO>().ReverseMap();
            CreateMap<ExcursionsScheduleModel, ExcursionsScheduleDTO>();
            CreateMap<ExcursionsScheduleModel, ExcursionsScheduleDTO>().ReverseMap();
            CreateMap<ExpositionModel, ExpositionDTO>();
            CreateMap<ExpositionModel, ExpositionDTO>().ReverseMap();
            CreateMap<GrafikModel, GrafikDTO>();
            CreateMap<GrafikModel, GrafikDTO>().ReverseMap();
        }
    }
}
