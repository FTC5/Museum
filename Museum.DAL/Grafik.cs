using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL
{
    [Table("Grafik")]
    public class Grafik
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key,ForeignKey("Exposition")]
        public int Id { get; set; }
        [Column("StartTime",TypeName = "time")]
        public TimeSpan StartTime { get; set; }
        [Column("EndTime", TypeName = "time")]
        public TimeSpan EndTime { get; set; }
        public virtual Exposition Exposition { get; set; }
        public virtual ExcursionsSchedule ExcursionsSchedule { get; set; }
    }
}
