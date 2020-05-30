using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Interfaces
{
    public interface IExpositionService
    {
        DTO.ExpositionDTO GetExpositionInfo(int id);
    }
}
