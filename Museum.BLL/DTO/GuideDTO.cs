using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.DTO
{
    public class GuideDTO : PersonDTO
    {
        private ICollection<CustomExcursionDTO> customExcursion;

        public virtual ICollection<CustomExcursionDTO> CustomExcursion
        {
            get { return customExcursion ?? (customExcursion = new List<CustomExcursionDTO>()); }
            set { customExcursion = value; }
        }
        private ICollection<ExcursionDTO> excursions;

        public virtual ICollection<ExcursionDTO> Excursions
        {
            get { return excursions ?? (excursions = new List<ExcursionDTO>()); }
            set { excursions = value; }
        }

        public override string ToString()
        {
            return Id.ToString()+" | Name "+Name.ToString();
        }
    }
}
