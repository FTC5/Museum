using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL
{
    [Table("Guide")]
    public class Guide : Persone
    {
        private ICollection<CustomExcursion> customExcursion;

        public virtual ICollection<CustomExcursion> CustomExcursion
        {
            get { return customExcursion ?? (customExcursion = new List<CustomExcursion>()); }
            set { customExcursion = value; }
        }
        private ICollection<Excursion> excursions;

        public virtual ICollection<Excursion> Excursions
        {
            get { return excursions ?? (excursions = new List<Excursion>()); }
            set { excursions = value; }
        }
    }
}
