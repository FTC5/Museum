using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL.Models
{
    public class ExcursionsScheduleModel
    {
        public int Id { get; set; }
        private ICollection<CustomExcursionModel> customExcursions;

        public virtual ICollection<CustomExcursionModel> CustomExcursions
        {
            get { return customExcursions ?? (customExcursions = new List<CustomExcursionModel>()); }
            set { customExcursions = value; }
        }      
        public virtual ExcursionModel Excursion { get; set; }
        public virtual GrafikModel Grafik { get; set; }

        public override string ToString()
        {
            string temp = "";
            temp = "Excursion\n Id : "+Excursion.ToString();
            foreach (CustomExcursionModel item in CustomExcursions)
            {
                temp += "CustomExcursions\n Id : " + item.ToString();
            }
            return temp;
        }
    }
}
