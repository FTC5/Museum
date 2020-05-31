using Museum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Interfaces
{
    public interface IExpositionService
    {
        ExpositionDTO GetExpositionInfo(int id);
        void DeleteExposition(int id);
        void UpdateExposition(ExpositionDTO exposition);
        void AddExposition(ExpositionDTO exposition);
    }
}
