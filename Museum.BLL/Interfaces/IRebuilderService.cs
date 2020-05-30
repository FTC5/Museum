using Museum.BLL.DTO;
using Museum.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Interfaces
{
    public interface IRebuilderService
    {
        IEnumerable<GrafikDTO> GrafikToGrafikDTO(IEnumerable<Grafik> grafiks);
        GrafikDTO GrafikToGrafikDTO(Grafik grafik);
        IEnumerable<ExpositionDTO> ExpositionToExpositionDTO(IEnumerable<Exposition> grafiks);
        ExpositionDTO ExpositionToExpositionDTO(Exposition exposition);
        CustomExcursionDTO CustomExcursionToCustomExcursionDTO(CustomExcursion customExcursion);
        IEnumerable<CustomExcursionDTO> CustomExcursionToCustomExcursionDTO(IEnumerable<CustomExcursion> customExcursion);
        IEnumerable<ExcursionDTO> ExcursionToExcursionDTO(IEnumerable<Excursion> excursion);
        ExcursionDTO ExcursionToExcursionDTO(Excursion excursion);
        IEnumerable<Customer> CustomerDTOToCustomer(IEnumerable<CustomerDTO> customers);
        Customer CustomerDTOToCustomer(CustomerDTO customerDTO);
    }
}
