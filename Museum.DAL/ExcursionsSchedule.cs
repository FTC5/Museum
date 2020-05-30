using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL
{
    [Table("ExcursionsSchedule")]
    public class ExcursionsSchedule
    {
        [Key,ForeignKey("Grafik")]
        public int Id { get; set; }
        private ICollection<CustomExcursion> customExcursions;

        public virtual ICollection<CustomExcursion> CustomExcursions
        {
            get { return customExcursions ?? (customExcursions = new List<CustomExcursion>()); }
            set { customExcursions = value; }
        }
        public virtual Excursion Excursion { get; set; }
        public virtual Grafik Grafik { get; set; }
    }
}
