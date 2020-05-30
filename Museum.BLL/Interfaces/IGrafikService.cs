using Museum.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.Interfaces
{
    public interface IGrafikService
    {
        IEnumerable<GrafikDTO> GetGrafiks();
        IEnumerable<GrafikDTO> FindByName(string name);
    }
}
