using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public   int Id { get; set; }
        public   int Age { get; set; }
        [Column("Name", TypeName = "ntext")]
        [MaxLength(40)]
        public   string Name { get; set; }
    }
}
