using Museum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Interfaces
{
    public interface IExcursionsScheduleService
    {
        bool SignUpToCustomExcursion(int excursionId, CustomerDTO customer);
        void SignUpToCustomExcursion(int excursionId, IEnumerable<CustomerDTO> customers);
        IEnumerable<CustomExcursionDTO> GetCustomExcursions(int id);
        ExcursionDTO GetScheduledExcursionsInfo(int id);
    }
}
