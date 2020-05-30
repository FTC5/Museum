using Museum.BLL.DTO;
using Museum.BLL.Interfaces;
using Museum.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Services
{
    public class RebuilderService : IRebuilderService
    {
        public IEnumerable<GrafikDTO> GrafikToGrafikDTO(IEnumerable<Grafik> grafiks)
        {
            List<GrafikDTO> list = new List<GrafikDTO>();
            foreach (var item in grafiks)
            {
                list.Add(GrafikToGrafikDTO(item));
            }
            return list;
        }
        public GrafikDTO GrafikToGrafikDTO(Grafik grafik)
        {
            GrafikDTO grafikDTO = new GrafikDTO();
            grafikDTO.Id = grafik.Id;
            grafikDTO.EndTime = grafik.EndTime;
            grafikDTO.ExpositionName = grafik.Exposition.ExpositionName;
            grafikDTO.StartTime = grafik.StartTime;
            return grafikDTO;
        }
        public IEnumerable<ExpositionDTO> ExpositionToExpositionDTO(IEnumerable<Exposition> grafiks)
        {
            List<ExpositionDTO> list = new List<ExpositionDTO>();
            foreach (var item in grafiks)
            {
                list.Add(ExpositionToExpositionDTO(item));
            }
            return list;
        }
        public ExpositionDTO ExpositionToExpositionDTO(Exposition exposition)
        {
            ExpositionDTO expositionDTO = new ExpositionDTO();
            expositionDTO.Id = exposition.Id;
            expositionDTO.ExpositionName = exposition.ExpositionName;
            expositionDTO.Plane = exposition.Plane;
            expositionDTO.Price = exposition.Price;
            expositionDTO.TargetAudience = exposition.TargetAudience;
            expositionDTO.Theme = exposition.Theme;
            return expositionDTO;
        }
        public CustomExcursionDTO CustomExcursionToCustomExcursionDTO(CustomExcursion customExcursion)
        {
            CustomExcursionDTO customExcursionDTO = new CustomExcursionDTO();
            customExcursionDTO.Id = customExcursion.Id;
            customExcursionDTO.StartTime = customExcursion.StartTime;
            customExcursionDTO.Time = customExcursion.Time;
            customExcursionDTO.GuideName = customExcursion.Guide.Name;
            return customExcursionDTO;
        }
        public IEnumerable<ExcursionDTO> ExcursionToExcursionDTO(IEnumerable<Excursion> excursion)
        {
            List<ExcursionDTO> list = new List<ExcursionDTO>();
            foreach (var item in excursion)
            {
                list.Add(ExcursionToExcursionDTO(item));
            }
            return list;
        }
        public ExcursionDTO ExcursionToExcursionDTO(Excursion excursion)
        {
            ExcursionDTO excursionDTO = new ExcursionDTO();
            excursionDTO.Id = excursion.Id;
            excursionDTO.StartTime = excursion.StartTime;
            excursionDTO.Time = excursion.Time;
            excursionDTO.GuideName = excursion.Guide.Name;
            return excursionDTO;
        }
        public IEnumerable<CustomExcursionDTO> CustomExcursionToCustomExcursionDTO(IEnumerable<CustomExcursion> customExcursion)
        {
            List<CustomExcursionDTO> list = new List<CustomExcursionDTO>();
            foreach (var item in customExcursion)
            {
                list.Add(CustomExcursionToCustomExcursionDTO(item));
            }
            return list;
        }
        public IEnumerable<Customer> CustomerDTOToCustomer(IEnumerable<CustomerDTO> customers)
        {
            List<Customer> list = new List<Customer>();
            foreach (var item in customers)
            {
                list.Add(CustomerDTOToCustomer(item));
            }
            return list;
        }
        public Customer CustomerDTOToCustomer(CustomerDTO customerDTO)
        {
            Customer customer = new Customer();
            customer.Age = customerDTO.Age;
            customer.Name = customer.Name;
            return customer;
        }
    }
}
