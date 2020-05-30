using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.PL.Models
{
    public class GuideModel : PersonModel
    {
        private ICollection<CustomExcursionModel> customExcursion;

        public virtual ICollection<CustomExcursionModel> CustomExcursion
        {
            get { return customExcursion ?? (customExcursion = new List<CustomExcursionModel>()); }
            set { customExcursion = value; }
        }
        private ICollection<ExcursionModel> excursions;

        public virtual ICollection<ExcursionModel> Excursions
        {
            get { return excursions ?? (excursions = new List<ExcursionModel>()); }
            set { excursions = value; }
        }

        public override string ToString()
        {
            return Id.ToString()+" | Name "+Name.ToString();
        }
    }
}
