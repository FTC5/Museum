using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.BLL.DTO
{
    public class ExcursionsScheduleDTO
    {
        public int Id { get; set; }
        private ICollection<CustomExcursionDTO> customExcursions;

        public virtual ICollection<CustomExcursionDTO> CustomExcursions
        {
            get { return customExcursions ?? (customExcursions = new List<CustomExcursionDTO>()); }
            set { customExcursions = value; }
        }      
        public virtual ExcursionDTO Excursion { get; set; }
        public virtual GrafikDTO Grafik { get; set; }

        public override string ToString()
        {
            string temp = "";
            temp = "Excursion\n Id : "+Excursion.ToString();
            foreach (CustomExcursionDTO item in CustomExcursions)
            {
                temp += "CustomExcursions\n Id : " + item.ToString();
            }
            return temp;
        }
    }
}
