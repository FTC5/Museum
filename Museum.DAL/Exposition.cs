using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL
{
    [Table("Exposition")]
    public class Exposition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column("Name", TypeName = "ntext")]
        [MaxLength(20)]
        public string ExpositionName { get; set; }
        [Column("Theme", TypeName = "ntext")]
        [MaxLength(20)]
        public string Theme { get; set; }
        public int TargetAudience { get; set; }
        [Column("Plane", TypeName = "ntext")]
        [MaxLength(60)]
        public string Plane { get; set; }
        public int Price { get; set; }
        public virtual Grafik Grafik { get; set; }
    }
}
