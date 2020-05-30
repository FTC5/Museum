using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL
{
    [Table("Excursion")]
    public class Excursion
    {
        [Key]
        public int Id { get; set; }
        public virtual Guide Guide { get; set; }
        [Column("StartTime", TypeName = "time")]
        public TimeSpan StartTime { get; set; }
        public int Time { get; set; }
        public virtual ExcursionsSchedule ExcursionsSchedule { get; set; }
    }
}
